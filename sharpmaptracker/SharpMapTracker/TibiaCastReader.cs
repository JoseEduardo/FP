using System;
using System.IO;

using SharpTibiaProxy.Domain;
using SharpTibiaProxy.Network;
using System.IO.Compression;
using System.Diagnostics;
using SharpTibiaProxy;

namespace SharpMapTracker
{
    public class TibiaCastReader
    {
        private enum TibiaCastPacketType : byte
        {
            a,
            b,
            c,
            d,
            e,
            f,
            CloseShopWindow,
            Initialize,
            TibiaPackets,
            Message,
            k = 11,
            l,
            m,
            n,
            o,
            p,
            q,
            r,
            s,
            t,
            u
        };

        private Client client;

        public TibiaCastReader(Client client)
        {
            this.client = client;
        }

        public IAsyncResult BeginRead(string[] fileNames, AsyncCallback callback, object @object)
        {
            return new ReadDelegate(Read).BeginInvoke(fileNames, callback, @object);
        }

        private delegate void ReadDelegate(string[] fileNames);
        public void Read(string[] fileNames)
        {
            int count = 0;

            foreach (var fileName in fileNames)
            {
                ++count;

                try
                {
                    if (!File.Exists(fileName))
                    {
                        Trace.WriteLine("[Error] Could not find the file " + fileName);
                        continue;
                    }

                    using (var fileStream = File.OpenRead(fileName))
                    {

                        var reader = new BinaryReader(fileStream);
                        var majorVersion = reader.ReadByte();
                        var minorVersion = reader.ReadByte();

                        if(majorVersion < 4 || (majorVersion == 4 && minorVersion < 3))
                        {
                            Trace.WriteLine("[Error] (" + Path.GetFileName(fileName) + ") Unsupported TibiaCast Version " + majorVersion + "." + minorVersion);
                            continue;
                        }

                        if (majorVersion > 4 || (majorVersion == 4 && minorVersion >= 5))
                            reader.ReadUInt32();

                        reader = new BinaryReader(new DeflateStream(fileStream, CompressionMode.Decompress));

                        Trace.WriteLine("[" + majorVersion + "." + minorVersion + "] Tracking " + Path.GetFileName(fileName) + " (" + count + " of " + fileNames.Length + ").");

                        var nextPacketTime = reader.ReadUInt32();

                        var buffer = new byte[ushort.MaxValue];
                        int packetSize;
                        do
                        {
                            packetSize = reader.ReadInt32();

                            if (packetSize == 0) //end
                                break;

                            reader.BaseStream.Read(buffer, 0, packetSize);
                            var message = new InMessage(buffer, packetSize);

                            ParsePacket(message);

                            nextPacketTime = reader.ReadUInt32();

                        } while (packetSize != 0);
                    }

                    Trace.WriteLine("File " + Path.GetFileName(fileName) + " successfully tracked.");
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("Exception while tracking " + Path.GetFileName(fileName)
                        + ". Details: " + ex.Message);
                }
            }
        }

        private void ParsePacket(InMessage message)
        {
            while (message.ReadPosition < message.Size)
            {
                var packetType = (TibiaCastPacketType)message.ReadByte();

                switch (packetType)
                {

                    case TibiaCastPacketType.CloseShopWindow:
                        //this.g(ax);
                        message.ReadByte();
                        break;
                    case TibiaCastPacketType.Initialize:
                        ParseInitialize(message);
                        break;
                    case TibiaCastPacketType.TibiaPackets:
                        ParseTibiaPackets(message);
                        break;
                    case TibiaCastPacketType.Message:
                        message.ReadString();
                        message.ReadString();
                        break;
                    default:
                        throw new Exception(string.Format("Unknown packet type ({0}) when reading TibiaCast file.", packetType));
                }
            }
        }

        private void ParseInitialize(InMessage message)
        {
            int count = message.ReadUShort();
            for (int i = 0; i < count; i++)
            {
                var creature = new Creature(message.ReadUInt());
                creature.Type = (CreatureType)message.ReadByte();
                creature.Name = message.ReadString();

                //Trace.WriteLine(String.Format("Creature[{0}]: {1}", i, creature.Name));

                creature.Health = message.ReadByte();
                var direction = (Direction)message.ReadByte();
                creature.LookDirection = direction;
                creature.TurnDirection = direction;

                //Outfit
                creature.Outfit = message.ReadOutfit();
                creature.LightLevel = message.ReadByte();
                creature.LightColor = message.ReadByte();
                creature.Speed = message.ReadUShort();
                creature.Skull = message.ReadByte();
                creature.Shield = message.ReadByte();
                creature.Emblem = message.ReadByte();
                creature.IsImpassable = message.ReadByte() == 0x01;

                client.BattleList.AddCreature(creature);
            }

            ParseTibiaPackets(message);
        }

        private void ParseTibiaPackets(InMessage message)
        {
            var packetCount = message.ReadUShort();
            for (int j = 0; j < packetCount; j++)
            {
                var packetSize = message.ReadUShort();
                var packet = message.ReadBytes(packetSize);
                var packetMessage = new InMessage(packet, packetSize);
                ParseTibiaPacket(packetMessage);
            }
        }

        private void ParseTibiaPacket(InMessage message)
        {
            var cmd = message.ReadByte();

            switch (cmd)
            {
                case 0x6C:
                case 0x6D:
                    var location = message.ReadLocation();
                    var stack = message.ReadByte();
                    if (location.IsCreature && !client.BattleList.ContainsCreature(location.GetCretureId(stack)))
                        return;
                    break;
            }

            message.ReadPosition = 0;
            client.ProtocolWorld.ParseServerMessage(message);
        }
    }
}