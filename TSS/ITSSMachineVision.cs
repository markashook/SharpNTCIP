using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    public enum ImageType
    {
        snapshot = 1,
        baseline = 2
    }

    public enum ImageOverlayType
    {
        none = 1,
        thisZone,
        allZones,
        defaultOverlay
    }

    public enum ImageFormat
    {
        bitmap = 1,
        jpeg
    }

    public enum BuildImageCommand
    {
        buildImage = 1,
        cancelBuildInProgress
    }

    public enum BuildImageStatus
    {
        noImage = 1,
        buildingImage,
        imageReady,
        genericError,
        invalidParameter, 
        noCameraForZone,
        multipleCamerasForZone,
        imageReceiveError,
        buildPending
    }

    public interface ITSSMachineVision
    {
        UInt16 maxCameraCount
        {
            get;
            set;
        }

        List<MachineVisionCameraEntry> machineVisionCameraTable
        {
            get;
            set;
        }

        UInt16 imageZoneNumber
        {
            get;
            set;
        }

        ImageType imageType
        {
            get;
            set;
        }

        ImageOverlayType imageOverlayType
        {
            get;
            set;
        }

        ImageFormat imageFormat
        {
            get;
            set;
        }

        UInt16 imageQuality
        {
            get;
            set;
        }

        BuildImageCommand buildImageCmd
        {
            get;
            set;
        }

        BuildImageStatus buildImageStatus
        {
            get;
            set;
        }


    }
}
