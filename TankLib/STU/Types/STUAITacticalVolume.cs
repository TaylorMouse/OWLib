// Generated by TankLibHelper
using TankLib.Math;

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x7FE73B95, 72)]
    public class STUAITacticalVolume : STUInstance
    {
        [STUField(0x50EA6228, 0)] // size: 16
        public uint[] m_50EA6228;
        
        [STUField(0x9BBD1060, 16, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STUAITacticalVolumeNeighbor[] m_9BBD1060;
        
        [STUField(0x7D1FC63E, 32)] // size: 12
        public teVec3 m_7D1FC63E;
        
        [STUField(0xFA78037A, 44)] // size: 4
        public int m_FA78037A;
        
        [STUField(0xFEF6FAAD, 48)] // size: 4
        public int m_FEF6FAAD;
        
        [STUField(0x13D4FCC5, 52)] // size: 4
        public uint m_13D4FCC5;
        
        [STUField(0x5BD33E19, 56)] // size: 4
        public float m_5BD33E19;
        
        [STUField(0xCE96F3F7, 60)] // size: 2
        public short m_CE96F3F7;
        
        [STUField(0xECE7575B, 62)] // size: 2
        public short m_ECE7575B;
        
        [STUField(0xD0EEE29A, 64)] // size: 2
        public short m_D0EEE29A;
        
        [STUField(0x090DE09F, 66)] // size: 2
        public short m_090DE09F;
        
        [STUField(0x5F565ED3, 68)] // size: 2
        public short m_5F565ED3;
        
        [STUField(0x4689A5FB, 70)] // size: 2
        public short m_4689A5FB;
    }
}
