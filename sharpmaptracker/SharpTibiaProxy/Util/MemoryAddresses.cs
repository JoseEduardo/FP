using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpTibiaProxy.Domain;

namespace SharpTibiaProxy.Util
{
    public class MemoryAddresses
    {
        public readonly long ClientRsa;
        public readonly long ClientServerStart;
        public readonly long ClientServerStep;
        public readonly long ClientServerMax;
        public readonly long ClientServerDistancePort;
        public readonly long ClientSelectedCharacter;

        public readonly long ClientMultiClient;
        public readonly byte ClientMultiClientJMP = 0xEB;
        public readonly byte ClientMultiClientJNZ = 0x75;

        public readonly long ClientStatus;

        public readonly long PlayerGoX;
        public readonly long PlayerGoY;
        public readonly long PlayerGoZ;

        public readonly long ClientBattleListStart;
        public readonly int ClientBattleListStep = 176;
        public readonly int ClientBattleListMaxCreatures = 1300;
        public readonly int ClientBattleListCreatureWalkDistance = 80;

        public MemoryAddresses(Client client)
        {
            if (client.Version == ClientVersion.Version961)
            {
                ClientRsa = client.BaseAddress + 0x320D40;
                ClientServerStart = client.BaseAddress + 0x3B06D0;
                ClientServerStep = 112;
                ClientServerMax = 10;
                ClientServerDistancePort = 100;
                ClientSelectedCharacter = client.BaseAddress + 0x3B9EF4;
                ClientMultiClient = client.BaseAddress + 0x12B387;

                ClientStatus = client.BaseAddress + 0x3B9EA8;

                PlayerGoX = 0;
                PlayerGoY = 0;
                PlayerGoZ = 0;

                ClientBattleListStart = 0;
            }
            else if (client.Version == ClientVersion.Version963)
            {
                ClientRsa = client.BaseAddress + 0x324EC0;
                ClientServerStart = client.BaseAddress + 0x3B34F8;
                ClientServerStep = 112;
                ClientServerMax = 10;
                ClientServerDistancePort = 100;
                ClientSelectedCharacter = client.BaseAddress + 0x3BCD10;
                ClientMultiClient = client.BaseAddress + 0x12E807;

                ClientStatus = client.BaseAddress + 0x3BCCC4;

                PlayerGoX = client.BaseAddress + 0x57FEA0;
                PlayerGoY = client.BaseAddress + 0x57FE98;
                PlayerGoZ = client.BaseAddress + 0x548004;

                ClientBattleListStart = client.BaseAddress + 0x548008;
            }
            else if (client.Version == ClientVersion.Version970)
            {
                ClientRsa = client.BaseAddress + 0x324EC0;
                ClientServerStart = client.BaseAddress + 0x3B34F8;
                ClientServerStep = 112;
                ClientServerMax = 10;
                ClientServerDistancePort = 100;
                ClientSelectedCharacter = client.BaseAddress + 0x3BCD10;
                ClientMultiClient = client.BaseAddress + 0x12EC57;

                ClientStatus = client.BaseAddress + 0x3BCCC4;

                PlayerGoX = client.BaseAddress + 0x57FEA0;
                PlayerGoY = client.BaseAddress + 0x57FE98;
                PlayerGoZ = client.BaseAddress + 0x548004;

                ClientBattleListStart = client.BaseAddress + 0x548008;
            }
            else
            {
                throw new Exception("The client version " + client.Version + " is not supported.");
            }
        }
    }
}
