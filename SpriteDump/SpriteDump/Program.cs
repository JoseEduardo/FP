using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpriteDump
{
    class Program
    {
        // String variable to hold the filename of the .date file.
        static string DatFileName = string.Empty;

        // String variable to hold the filename of the .spr file.
        static string SprFileName = string.Empty;

        // Flags in the .dat file each object could have.
        static byte Flag_Bank = 0;
        static byte Flag_Clip = 1;
        static byte Flag_Bottom = 2;
        static byte Flag_Top = 3;
        static byte Flag_Container = 4;
        static byte Flag_Cumulative = 5;
        static byte Flag_ForceUse = 6;
        static byte Flag_MultiUse = 7;
        static byte Flag_Write = 8;
        static byte Flag_WriteOnce = 9;
        static byte Flag_LiquidContainer = 10;
        static byte Flag_LiquidPool = 11;
        static byte Flag_Unpass = 12;
        static byte Flag_Unmove = 13;
        static byte Flag_Unsight = 14;
        static byte Flag_Avoid = 15;
        static byte Flag_NoMovementAnimation = 16;
        static byte Flag_Take = 17;
        static byte Flag_Hang = 18;
        static byte Flag_HookSouth = 19;
        static byte Flag_HookEast = 20;
        static byte Flag_Rotate = 21;
        static byte Flag_Light = 22;
        static byte Flag_DontHide = 23;
        static byte Flag_Translucent = 24;
        static byte Flag_Shift = 25;
        static byte Flag_Height = 26;
        static byte Flag_LyingObject = 27;
        static byte Flag_AnimateAlways = 28;
        static byte Flag_Automap = 29;
        static byte Flag_LensHelp = 30;
        static byte Flag_FullBank = 31;
        static byte Flag_IgnoreLook = 32;
        static byte Flag_Clothes = 33;
        static byte Flag_Market = 34;
        static byte Flag_Default_Action = 35;
        static byte Flag_Usable = 254;

        static void ParseDatFile()
        {
            // Use a BinaryReader object to read the .dat file in bytes.
            // "using" automatically closes the file when exited.
            using (System.IO.BinaryReader reader = new System.IO.BinaryReader(System.IO.File.OpenRead(DatFileName)))
            {
                // Unique value for each .dat file.
                UInt32 DatVersion = reader.ReadUInt32();
                // Number of items.
                UInt16 ItemCount = reader.ReadUInt16();
                // Number of outfits.
                UInt16 OutfitCount = reader.ReadUInt16();
                // Number of effects.
                UInt16 EffectCount = reader.ReadUInt16();
                // Number of projectiles.
                UInt16 ProjectileCount = reader.ReadUInt16();

                // Add number of items, outfits, effects, and projectiles together so we know how many objects to loop through.
                int maxID = ItemCount + OutfitCount + EffectCount + ProjectileCount;
                // Set ID equal to 100 because the first object ID is 100.
                // This is helpful if you want to store all the information for each object in an array, and you'll automatically know the ID of that item.
                // Eg., when we are on ID: 3031 we are on the information for gold coin.
                int ID = 100;

                // Loop through each object.
                while ((ID < maxID))
                {
                    // Read first flag.
                    byte flag = reader.ReadByte();
                    // Loop until flag equals 255.
                    while (flag != 255)
                    {
                        // Is ground object. (Grass)
                        if (flag == Flag_Bank)
                        {
                            // Speed at which a creature can move when on it.
                            reader.ReadUInt16();
                        }
                        // Overlay order. (Door)
                        else if (flag == Flag_Clip) { }
                        // Overlay order. (Sewer Grate)
                        else if (flag == Flag_Bottom) { }
                        // Overlay order. (Roof)
                        else if (flag == Flag_Top) { }
                        // Container object. (Backpack)
                        else if (flag == Flag_Container) { }
                        // Can be stacked. (Gold)
                        else if (flag == Flag_Cumulative) { }
                        // Can only be used, cannot be used with. (Food)
                        else if (flag == Flag_ForceUse) { }
                        // Can be used and used with. (Potion)
                        else if (flag == Flag_MultiUse) { }
                        // Can be written on, and read. (Letter)
                        else if (flag == Flag_Write)
                        {
                            // Max length of text that can be written.
                            reader.ReadUInt16();
                        }
                        // Can only be read. (Blackboard)
                        else if (flag == Flag_WriteOnce)
                        {
                            // Max length of text that can be on it.
                            reader.ReadUInt16();
                        }
                        // Holds liquid. (Vial)
                        else if (flag == Flag_LiquidContainer) { }
                        // Liquid on ground. (Blood)
                        else if (flag == Flag_LiquidPool) { }
                        // Cannot be walked on. (Tree)
                        else if (flag == Flag_Unpass) { }
                        // Cannot be moved. (Statue)
                        else if (flag == Flag_Unmove) { }
                        // Blocks projectiles. (Wall)
                        else if (flag == Flag_Unsight) { }
                        // Character attempts to avoid when auto-walking. (Fire Field)
                        else if (flag == Flag_Avoid) { }
                        // I got nothing. (?)
                        else if (flag == Flag_NoMovementAnimation) { }
                        // Can be picked up. (Sword)
                        else if (flag == Flag_Take) { }
                        // Can be hung on a wall. (Tapestry)
                        else if (flag == Flag_Hang) { }
                        // Hangs facing South. (Dragon Lord Trophy)
                        else if (flag == Flag_HookSouth) { }
                        // Hangs facing East. (Behemoh Trophy)
                        else if (flag == Flag_HookEast) { }
                        // Can be rotated. (Chair)
                        else if (flag == Flag_Rotate) { }
                        // Gives off light. (Torch)
                        else if (flag == Flag_Light)
                        {
                            // Brightness.
                            reader.ReadUInt16();
                            // Color.
                            reader.ReadUInt16();
                        }
                        // Who knows. (?)
                        else if (flag == Flag_DontHide) { }
                        // Can be seen through? (?)
                        else if (flag == Flag_Translucent) { }
                        // Is shifted when drawn. (?)
                        else if (flag == Flag_Shift)
                        {
                            // Shift on x-axis.
                            reader.ReadUInt16();
                            // Shift on y-axis.
                            reader.ReadUInt16();
                        }
                        // Height? (?)
                        else if (flag == Flag_Height)
                        {
                            // Elevation?
                            reader.ReadUInt16();
                        }
                        // White lies? (?)
                        else if (flag == Flag_LyingObject) { }
                        // Is always animated. (Energy Field)
                        else if (flag == Flag_AnimateAlways) { }
                        // Is a pixel on the automap. (Mountain)
                        else if (flag == Flag_Automap)
                        {
                            // Color. (Mountain = Gray)
                            reader.ReadUInt16();
                        }
                        // Has extra "help" information (eg. IsLadder, IsSewer, IsDoor, etc.)
                        else if (flag == Flag_LensHelp)
                        {
                            // Help value. (IsLadder = 0x44C; Could be different now.)
                            reader.ReadUInt16();
                        }
                        // Has to do with ground objects. (?)
                        else if (flag == Flag_FullBank) { }
                        // I'm assuming it's ignored when you look at it. (?)
                        else if (flag == Flag_IgnoreLook) { }
                        // Can be placed in an inventory slot. (Helmet, Armor, Legs, etc.)
                        else if (flag == Flag_Clothes)
                        {
                            // Inventory slot.
                            reader.ReadUInt16();
                        }
                        // Can be bought/sold in the Market. (Demon Shield)
                        else if (flag == Flag_Market)
                        {
                            // Market category. (Tools, Valuables, Premium Scrolls, etc.)
                            reader.ReadUInt16();
                            // ID of item for which sprite is displayed for trade.
                            reader.ReadUInt16();
                            // ID of item for which sprite is displayed when shown.
                            reader.ReadUInt16();
                            // Name length.
                            UInt16 MarketNameLength = reader.ReadUInt16();
                            // Name. Encoded with "iso-8859-1".
                            reader.ReadBytes(MarketNameLength);
                            /* Replace the line above (reader.ReadBytes(MarketNameLength);) with System.Text.Encoding.GetEncoding("iso-8859-1").GetString(reader.ReadBytes(MarketNameLength));
                            to get the actual string. */
                            // Profession object is restricted to. (eg., Knight)
                            reader.ReadUInt16();
                            // Level object is restricted to. (eg., Level 100)
                            reader.ReadUInt16();
                        }
                        // Has a default action when clicked on (Smart-Click).
                        else if (flag == Flag_Default_Action)
                        {
                            // Default action.
                            reader.ReadUInt16();
                        }
                        // Is usable. My guess is this relates to the Smart-Click feature.
                        else if (flag == Flag_Usable) { }
                        // Invalid  flag!
                        else { }

                        // Read next flag.
                        flag = reader.ReadByte();
                    }

                    // Width.
                    byte Width = reader.ReadByte();
                    // Height.
                    byte Height = reader.ReadByte();

                    // If more than 1 sprite wide, or high.
                    if (Width > 1 | Height > 1)
                    {
                        // Exact size.
                        reader.ReadByte();
                    }
                    //else { exact size is 32 }

                    // Layers.
                    byte Layers = reader.ReadByte();
                    // Pattern width.
                    byte PatternWidth = reader.ReadByte();
                    // Pattern height.
                    byte PatternHeight = reader.ReadByte();
                    // Pattern depth.
                    byte PatternDepth = reader.ReadByte();
                    // Animation phases.
                    byte Phases = reader.ReadByte();

                    // Multiply width, height, layers, pattern width, pattern height, pattern depth, and phases to get number of sprites.
                    Int32 NumberOfSprites = Width * Height * Layers * PatternWidth * PatternHeight * PatternDepth * Phases;

                    // Loop to get each sprite.
                    for (Int32 i = 0; i < NumberOfSprites; i++)
                    {
                        // Since the 9.60 client, sprite IDs are stored in 4 bytes.
                        // Before 9.60, sprite IDs were stored in 2 bytes.
                        
                        // Sprite ID.
                        UInt32 SpriteID = reader.ReadUInt32();

                        // Create empty bitmap for sprite.
                        System.Drawing.Bitmap Sprite = null;

                        // Make sure the sprites ID is not 0 before calling the function to get its bitmap.
                        if (SpriteID > 0)
                        {
                            try
                            {
                                // Call function to get the bitmap for the sprite.
                                Sprite = GetSpriteBitmap(SpriteID);

                                // Make sure a folder for the sprites exists in the directory you launched the executable from.
                                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Sprites/"))
                                {
                                    // If not, create it.
                                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Sprites/");
                                }

                                // Save the sprite to the sprites folder in the format: "ItemID (SpriteID).png"
                                //Sprite.Save("Sprites/" + ID.ToString() + " (" + SpriteID.ToString() + ").png", System.Drawing.Imaging.ImageFormat.Png);
                                Sprite.Save("Sprites/" + ID.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                            }
                            catch
                            {

                            }
                        }
                    }

                    // Increase ID by 1 to continue the loop.
                    ID += 1;
                }
            }
        }

        static System.Drawing.Bitmap GetSpriteBitmap(UInt32 SpriteID)
        {
            // Use a BinaryReader object to read the .spr file in bytes.
            // "using" automatically closes the file when exited.
            using (System.IO.BinaryReader reader = new System.IO.BinaryReader(System.IO.File.OpenRead(SprFileName)))
            {
                // Create an empty 32 pixel by 32 pixel bitmap for the sprite.
                System.Drawing.Bitmap Sprite = new System.Drawing.Bitmap(32, 32);
                // Lock the sprite's bits. This makes creating bitmap images 100x more efficient than SetPixel().
                System.Drawing.Imaging.BitmapData SpriteData = Sprite.LockBits(new System.Drawing.Rectangle(0, 0, 32, 32), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                // Create byte array to store data for each pixel. There are 1024 pixels in a 32x32 pixel image, and each pixel holds 4 bytes of data (4096 bytes of data).
                byte[] PixelData = new byte[4096];

                // Seek ahead to the SpriteID. 8 is the number of bytes of the information at the beginning of the .spr file (SprVersion 4-bytes, NumberOfSprites 4-bytes).
                // Sprite IDs start at 2 so we have to subtract one to get the offset. Multiply by 4 because offsets are stored in 4-bytes.
                // Eg., after the first 8 bytes it starts the 4-byte offsets for each sprite ID. The first 4 bytes are empty (if I remember correctly).
                reader.BaseStream.Seek(8 + (SpriteID - 1) * 4, System.IO.SeekOrigin.Begin);
                // Reading 4-bytes will tell us the offset of our sprite ID. Skip 3 bytes because those hold the transparent pixel information for that sprite ID (this is usually/always magenta).
                reader.BaseStream.Seek(reader.ReadUInt32() + 3, System.IO.SeekOrigin.Begin);

                // The next 2 bytes hold the size of the sprite in pixels. I add it to the stream position to make my while loop easier to maintain.
                long SpriteSize = reader.BaseStream.Position + reader.ReadUInt16();

                // Create current pixel counter and set it to 0.
                UInt16 CurrentPixel = 0;

                // Loop through each pixel.
                while (reader.BaseStream.Position < SpriteSize)
                {
                    // 2 bytes hold the number of transparent pixels before there's a colored pixel.
                    UInt16 TransparentPixels = reader.ReadUInt16();
                    // 2 bytes hold the number of colored pixels before a transparent pixel.
                    UInt16 ColoredPixels = reader.ReadUInt16();

                    // Skip past the transparent pixels because we only need the colored pixels.
                    CurrentPixel += TransparentPixels;

                    // Loop through the colored pixels.
                    for (int i = 0; i < ColoredPixels; i++)
                    {

                         // This is just the offset in our PixelData array that makes it easier to store each byte for each pixel's color.
                         Int32 CurrentOffset = CurrentPixel * 4;

                        // Last byte in the current offset is the Alpha channel and it's always transparent.
                        PixelData[CurrentOffset + 3] = 255;
                        // Third byte in the current offset is the Red channel, and the first byte we read for this pixel.
                        PixelData[CurrentOffset + 2] = reader.ReadByte();
                        // Second byte in the current offset is the Blue channel, and the second byte we read for this pixel.
                        PixelData[CurrentOffset + 1] = reader.ReadByte();
                        // First byte in the current offset is the Green channel, and the last byte we read for this pixel.
                        PixelData[CurrentOffset] = reader.ReadByte();

                        // Increase the CurrentPixel counter by 1.
                        CurrentPixel += 1;
                    }
                }

                // Copy the bytes from our PixelData array to the BitmapData object we created when locking the Sprite bitmap's bits.
                System.Runtime.InteropServices.Marshal.Copy(PixelData, 0, SpriteData.Scan0, 4096);
                // Unlock Sprite bitmap's bits.
                Sprite.UnlockBits(SpriteData);
                // Return the Sprite ID's bitmap.
                return Sprite;
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            // Ask the user to press the Enter key then locate the .dat file.
            Console.WriteLine("Press Enter then locate the .dat file.");
            // Wait for user to press a key.
            Console.ReadKey();

            // Create an OpenFileDialog object to easily locate the .dat and .spr files.
            System.Windows.Forms.OpenFileDialog OpenFileDialog = new System.Windows.Forms.OpenFileDialog
            {
                // Set the filter to .dat files.
                Filter = "Dat file (*.dat)|*.dat|All files (*.*)|*.*"
            };

            // Check which button the user pressed on the OpenFileDialog window.
            if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // If 'OK', set our empty dat filename string to the filename of the selected file.
                DatFileName = OpenFileDialog.FileName;
            }
            else
            {
                // Otherwise, leave the function. Which will close the program.
                return;
            }

            // Ask the user to press the Enter key then locate the .spr file.
            Console.WriteLine("Press Enter then locate the .spr file.");
            // Wait for user to press a key.
            Console.ReadKey();

            // Set the filter to .spr files so we can get the .spr file next.
            OpenFileDialog.Filter = "Spr File (*.spr)|*.spr|All files (*.*)|*.*";

            if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // If 'OK', set our empty spr filename string to the filename of the selected file.
                SprFileName = OpenFileDialog.FileName;
            }
            else
            {
                // Otherwise, leave the function. Which will close the program.
                return;
            }

            // Tell user to wait patiently for dump to finish, we will let them know when it is finished.
            Console.WriteLine("Please wait while sprites are dumped. You will be notified when this operation is complete.");

            // I'm going to create a stopwatch object to calculate how long it takes to dump all the sprites.
            System.Diagnostics.Stopwatch Stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // Call our function to parse the .dat file.
            ParseDatFile();

            // Tell user how long it took to dump all the sprites.
            Console.WriteLine("It took " + Stopwatch.ElapsedMilliseconds.ToString() + " milliseconds to dump sprites.");
            
            // Ask user to press the Enter key to close the application.
            Console.WriteLine("Press Enter to close the application.");
            // Wait for user to press a key before closing application.
            Console.ReadKey();
        }
    }
}
