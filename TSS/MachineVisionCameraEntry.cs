using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    public enum CameraDetectionState
    {
        detectionIsNotDisabled = 1,
        detectionIsDisabled
    }

    public enum BaselineImage
    {
        notSupported = 1,
        supportedAndAvailable,
        supportedButNotAvailable
    }

    public enum SnapshotImageSupport
    {
        notSupported = 1,
        supported
    }

    public abstract class MachineVisionCameraEntry
    {

        UInt16 cameraNumber
        {
            get;
            set;
        }

        string cameraNameLabel
        {
            get;
            set;
        }

        UInt16 imageReceptionDiagnostic
        {
            get;
            set;
        }

        CameraDetectionState cameraDetectionState
        {
            get;
            set;
        }

        bool[] zoneListForCamera
        {
            get;
            set;
        }

        BaselineImage baselineImage
        {
            get;
            set;
        }

        SnapshotImageSupport snapshotImage
        {
            get;
            set;
        }
        
        bool[] cameraImageFormat
        {
            get;
            set;
        }
    }
}
