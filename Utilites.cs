﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Utilities
    {


        
        public static string[] SplitFramesString(string framesString, int maxFrameNumber)
        {
            string[] framesStringArray = Array.Empty<string>();
            if (framesString.Contains("|"))
            {
                framesStringArray = framesString.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                if (framesStringArray.Length > maxFrameNumber)
                {
                    throw new ArgumentException($"Sorry, you have {framesStringArray.Length} frames, " +
                        $"which is higher than Max number of {maxFrameNumber} frames allowed for this game.");
                }
            }
            return framesStringArray;
        }

        
        public static int ProcessCharArray(char characterInString, Frame Frames, int stratingPinsNumber)
        {
            int pinsCount = 0;

            if (characterInString >= '0' && characterInString <= '9')
            {
                Frames.Throws.Add((int)char.GetNumericValue(characterInString));
                pinsCount = int.Parse(characterInString.ToString());
            }
            else if (characterInString.ToString().ToUpperInvariant() == "X")
            {
                Frames.IsStrike = true;
                Frames.IsFrameOver = true;
                Frames.Throws.Add(10);
                pinsCount = 10;
            }
            else if (characterInString.ToString().ToUpperInvariant() == "/")
            {
                Frames.IsSpare = true;
                Frames.IsFrameOver = true;
                Frames.Throws.Add(stratingPinsNumber - Frames.Throws[0]);
                pinsCount = 10;
            }
            else if (characterInString.ToString().ToUpperInvariant() == "-")
            {
                Frames.Throws.Add(0);
                pinsCount += 0;
            }
            else if (characterInString.ToString().ToUpperInvariant() == "/" && Frames.IsLastFrame && Frames.IsBonusAllowed)
            {
                throw new ArgumentException("The Spare cannot be set on the Bonus Throws, please check.");
            }
            else
            {
                throw new ArgumentException($"Invalid argument '{characterInString}' was detected in the provided input, please check.");
            }

            return pinsCount;
        }
    }
}
