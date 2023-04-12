// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;

namespace QProtocol
{
    /// <summary>
    /// This class can be used to decode the System Time Endpoint request.
    /// </summary>
    [Serializable]
    public class SystemTime
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        public int Hour { get; set; }

        public int Minutes { get; set; }

        public int Seconds { get; set; }

        public static SystemTime GetPresentTime()
        {
            return new SystemTime
            {
                Year = DateTime.Now.Year,
                Month = DateTime.Now.Month,
                Day = DateTime.Now.Day,
                Hour = DateTime.Now.Hour,
                Minutes = DateTime.Now.Minute,
                Seconds = DateTime.Now.Second,
            };
        }
    }
}
