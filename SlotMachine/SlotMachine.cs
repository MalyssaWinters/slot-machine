using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class SlotMachine
    {
        public int NumberOfSlots { get; set; }
        private int _numberOfSlots
        {
            get
            {
                return _numberOfSlots;
            }
            set
            {
                _numberOfSlots = value;
                icons = new int[value]; // could also put [_numberOfSlots]
            }
        }
        public int IconsPerSlot { get; set; }
        public int MinimumBet { get; set; }
        public int MaximumBet { get; set; }
        private Random random;

        private int _currentBet;
        public int CurrentBet
        {
            get
            {
                return _currentBet;
            }
            set
            {
                _currentBet = value;
                if (_currentBet < MinimumBet)
                {
                    _currentBet = MinimumBet;
                }
                if (_currentBet > MaximumBet)
                {
                    _currentBet = MaximumBet;
                }
            }
        }

        /// <summary>
        /// An array of integers that is as long as the number of slots,
        /// with each element of the array representing a different slot
        /// </summary>

        private int[] icons;

        public SlotMachine()
        {
            NumberOfSlots = 3;
            IconsPerSlot = 5;
            MinimumBet = 1;
            MaximumBet = 100;
            // Random(); is actually a pseudo-random generator; meaning it starts at a seed
            // then does some math off of that seed to get the next 'random' number
            // and continues the same math to get the next 'random' number
            random = new Random();
        }

        /// <summary>
        /// Randomizes the contents of the icons
        /// </summary>
        public void PullLever()
        {
            // TODO
            // loop over the icons
            // pick random numbers
            for (int i = 0; i < icons.Length; i++)
            {
                icons[i] = random.Next(1, IconsPerSlot + 1);
                // incons[i] = random.Next(IconsPerSlot) + 1;
            }
        }

        /// <summary>
        /// Return the results from the slots
        /// </summary>
        /// <returns>an int[] with each slot as an element of the array</returns>
        public int[] GetResults()
        {
            // TODO
            PullLever();
            return icons;
        }

        /// <summary>
        /// Examine the contents of the slots and determine the appropriate payout
        /// based upon the CurrentBet.
        /// </summary>
        /// <returns>number of pennies to pay out</returns>
        public int GetPayout()
        {
            int slot1 = icons[0];
            int payout = 0;
            int equalCount = 0;

            for (int i = 1; i < icons.Length; i++)
            {
                if (icons[i] == slot1)
                {
                    equalCount++;
                }
                if (equalCount == icons.Length - 1)
                {
                    payout = slot1 * CurrentBet * 100;
                }
            }
            return payout;
        }

    }
}
