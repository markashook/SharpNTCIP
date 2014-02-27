using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedSensorLib
{
    /// <summary>
    /// Stores an NTCIP 1209 TSS speed measuring device sample
    /// </summary>
    class SpeedSensorSample
    {
        public uint sensor_id
        {
            get { return sensor_id; }
            set { sensor_id = value; }
        }

        public uint zone_id
        {
            get { return zone_id; }
            set { zone_id = value; }
        }

        public uint class_id
        {
            get { return class_id; }
            set { class_id = value; }
        }

        public float volume
        {
            get { return volume; }
            set { volume = value; }
        }

        public float occupancy
        {
            get { return occupancy; }
            set { occupancy = value; }
        }

        public float speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public DateTime sample_end_time
        {
            get { return sample_end_time; }
            set { sample_end_time = value; }
        }

        public uint zone_status
        {
            get { return status; }
            set { status = value; }
        }

        public uint sequence_number
        {
            get { return sequence_number; }
            set { sequence_number = value; }
        }

        public bool timestamp_since_tss_reset
        {
            get { return timestamp_since_tss_reset; }
            set { timestamp_since_tss_reset = value; }
        }
    }
}
