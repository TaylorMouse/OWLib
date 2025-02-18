// Generated by TankLibHelper
using TankLib.Math;

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x978A87DE, 144)]
    public class STUAnimGameData_PoseData : STUInstance
    {
        [STUField(0x44B8E377, 0)] // size: 16
        public teVec3A m_44B8E377;
        
        [STUField(0x0B5E9CF6, 16, ReaderType = typeof(InlineInstanceFieldReader))] // size: 48
        public STU_7C02B6CA m_0B5E9CF6;
        
        [STUField(0x03E0A520, 64)] // size: 16
        public teVec3A[] m_poseDataVecs;
        
        [STUField(0xD65E1B08, 80, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STUAnimGameData_GeoSetFlags[] m_geoSetFlags;
        
        [STUField(0x699307AB, 96)] // size: 16
        public float[] m_699307AB;
        
        [STUField(0x7B071C78, 112)] // size: 16
        public float[] m_7B071C78;
        
        [STUField(0xDB11C2C0, 128)] // size: 4
        public uint m_animationID;
        
        [STUField(0xE0D91786, 132)] // size: 4
        public uint m_E0D91786;
        
        [STUField(0x7EEFB57A, 136)] // size: 2
        public ushort m_flags;
        
        [STUField(0xAE2D8911, 138)] // size: 2
        public ushort m_index;
        
        [STUField(0x3016B9A1, 140)] // size: 2
        public ushort m_3016B9A1;
        
        [STUField(0xC1B611DF, 142)] // size: 2
        public ushort m_C1B611DF;
    }
}
