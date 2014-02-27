using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    /// <summary>
    /// Identifies which historical sampling period that data is being requested from.  
    /// 0 being the sampling period currently in progress.  
    /// 1 being the most recently completed sampling period.
    /// 
    /// Reference:          NTCIP1209v0209
    /// </summary>
    public enum SampleEntryNumber
	{
        InProgress = 0, MostRecentCompleted, SecondmostRecentCompleted, ThirdmostRecentCompleted, ForthmostRecentCompleted  
	}

    /// <summary>
    /// Detailed status returned as result of diagnostics, as follows:
    /// Value - Meaning
    /// 
    /// --other(1) -  Status returned indicating an error has occurred within the device for
    /// which there is no defined definition within this data element
    /// 
    /// --oK(2) -  Status returned indicating no other status values apply
    /// 
    /// --initializing(3) -   Status returned indicating an initialization or diagnostics 
    /// procedure is in progress
    /// 
    /// --noActivity(4) -   Status returned indicating no activity condition
    /// 
    /// --maxPresence(5) -   Status returned indicating max presence condition
    /// 
    /// --configurationError(6) -   Status returned indicating an error within the device 
    /// configuration setup
    /// 
    /// --erraticCounts(7 )-   Status returned indicating erratic counts
    /// 
    /// --disabled(8) -   Status returned indicating that the zone is disabled
    /// 
    /// --overrideActive(9) -   Status returned indicating an override is active
    /// 
    /// --sensorFailure(10) -   Status returned indicating a sensing element failure
    /// 
    /// --inputDataIntegrity(11) -   Status returned indicating input values are not 
    /// sufficient to determine detector data accurately (e.g., bad communications, 
    /// invalid video for machine vision)
    /// 
    /// --poorContrast(12) -   Status returned indicating insufficient contrast error 
    /// condition
    /// 
    /// --detectionAutoSuspended(13) -   Status returned indicating that the detection zone 
    /// was automatically disabled by the TSS device (e.g., camera is on a PTZ and was 
    /// moved)
    /// 
    /// --pairedZoneFault(14) - This zone status indicates that there was no problem with 
    /// this zone, but a zone that it is paired with had a fault. This may affect the 
    /// accuracy of data reported by this zone.
    /// 
    /// Reference:          NTCIP1209v0209
    /// </summary>
    public enum ZoneStatus
    {
        other=0, oK, initializing, noActivity, maxPresence, configurationError, erraticCounts, disabled, overrideActive, sensorFailer, inputDataIntegrity, poorContrast, detectionAutoSuspended, pairedZoneFault
    }

    /// <summary>
    /// Table containing the historical sample period data.  The number of rows in this 
    /// table is equal to the maxSensorZones data element multiplied by the 
    /// maxSampleDataEntries data element.  Table rows are set by the manufacturer, and row 
    /// creation/deletion is not supported.
    /// 
    /// To retrieve all historical data entries for a zone, the last (oldest) entry should 
    /// be retrieved by using numSampleDataEntries and retrieving class 0 through 
    /// numSensorZoneClass first.  Class zero is an aggregation of the data from all of the 
    /// other classes (if any exist).  All of the class data for a particular 
    /// numSampleDataEntries will have the same sequenceNumber. Once these entries are 
    /// retrieved, the other entries sequence numbers denote the correct order of the 
    /// samples.  Sequence number is used rather than end date as the system clock may have 
    /// been reset between data samples.
    /// 
    /// TableType:              static
    /// NTCIP OID:              1.3.6.1.4.1.1206.4.2.4.3.4
    /// Reference:              NTCIP1209v0209
    /// </summary>
    public class SampleDataEntry
    {
        /// <summary>
        /// This would identify which historical sampling period that data is being 
        /// requested from.  0 being the sampling period currently in progress.  1 being the
        /// most recently completed sampling period.
        /// 
        /// NTCIP OID:          1.3.6.1.4.1.1206.4.2.4.3.4.1.1
        /// Reference:          NTCIP1209v0209
        /// </summary>
        public SampleEntryNumber sampleEntryNum
        {
            get;
            set;
        }

        /// <summary>
        /// This identifies the class of the sensor zone from which historical sampling period 
        /// data is being requested.  Class 0 will retrieve an aggregate of the data from all 
        /// classes within the requested historical data entry.
        /// 
        /// NTCIP OID:          1.3.6.1.4.1.1206.4.2.4.3.4.1.2
        /// Reference:          NTCIP1209v0209
        /// </summary>
        public byte sampleZoneClass
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the time at which the data collection period ended for the data 
        /// contained in this row.  If the clockAvailable data element indicates the 
        /// presence of a clock, this time shall be expressed in local time as expressed 
        /// as """The current local time expressed in seconds since 00:00:00 (midnight) 
        /// January 1, 1970 of the same time offset.  This value changes by 3600 seconds in 
        /// response to a daylight saving time event."""; otherwise, this time shall be 
        /// expressed in the number of seconds since the most recent device initialization.
        /// 
        /// Unit:           seconds
        /// NTCIP OID:      1.3.6.1.4.1.1206.4.2.4.3.4.1.3
        /// Reference:      NTCIP1209v0209 and NTCIP1201v0307
        /// </summary>
        public UInt32 sampleEndTime
        {
            get;
            set;
        }

        /// <summary>
        /// Counts per sample period.  Counts are expressed as an integer value in the 
        /// sampleVolumeData data element.  The value of 65535 shall be returned to 
        /// represent a missing value.  A missing value is reported when the zoneStatus is 
        /// anything other than OK for the entire sampling period.
        /// 
        /// Units:          count
        /// NTCIP OID:      1.3.6.1.4.1.1206.4.2.4.3.4.1.4
        /// Reference:      NTCIP1209v0209
        /// </summary>        
        public UInt16 sampleVolumeData
        {
            get;
            set;
        }

        /// <summary>
        /// Percent occupancy over the sample period.  Occupancy is expressed in tenths of a
        /// percent, from 0 to 100.0 percent, in the samplePercentOccupancy data element.  
        /// The value of 65535 shall be return to represent an invalid or missing value.  A 
        /// missing value is reported when the zoneStatus is anything other than OK for the 
        /// entire sampling period.  Values 1001 through 65534 are reserved for future use.
        /// 
        /// Units:          percent
        /// NTCIP OID:      1.3.6.1.4.1.1206.4.2.4.3.4.1.5
        /// Reference:      NTCIP1209v0209
        /// </summary>
        public UInt16 samplePercentOccupancy
        {
            get;
            set;
        }

        /// <summary>
        /// Arithmetic mean of speeds collected over the sample period with units of 1/10ths
        /// of km/h.  For a volume of zero during the sample period, the value of 65535 
        /// shall be returned to represent an invalid or missing value.  A missing value is 
        /// reported when the zoneStatus returned indicates no other status values apply for
        /// the entire sampling period.  Values 2551 through 65534 are reserved for future 
        /// use.
        /// Units:          tenths of km/h
        /// NTCIP OID:      1.3.6.1.4.1.1206.4.2.4.3.4.1.6
        /// Reference:      NTCIP1209v0209
        /// </summary>
        public UInt16 sampleSpeedData
        {
            get;
            set;
        }

        /// <summary>
        /// Detailed status returned as result of diagnostics
        /// If a condition occurs during the sample period, then that state remains for the duration of that sample period.  If multiple conditions occur during a sample period, the last reported condition, other than OK, is retained.
        /// 
        /// NTCIP OID:          1.3.6.1.4.1.1206.4.2.4.3.4.1.7
        /// Reference:          NTCIP1209v0209
        /// </summary>
        public ZoneStatus sampleZoneStatus
        {
            get;
            set;
        }

        /// <summary>
        /// The data samples sequence number, used to determine the appropriate order of 
        /// samples for a particular zone.  All data from the same sampling period will have
        /// the same historical sequence number (all classes from the same period will have 
        /// the same sequence number). 
        /// 
        /// Units:              count
        /// NTCIP OID:          1.3.6.1.4.1.1206.4.2.4.3.4.1.8
        /// Reference:          NTCIP1209v0209
        /// </summary>
        public UInt16 sampleSequenceNumber
        {
            get;
            set;
        }
    }
}
