// Generated by TankLibHelper
using TankLib.Math;

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0xC18DC9CD, 144)]
    public class STUMapLayer : STUInstance
    {
        [STUField(0x1A37A8D5, 8)] // size: 16
        public teStructuredDataAssetRef<STUMapLayer>[] m_1A37A8D5;
        
        [STUField(0xA8F4AE5B, 24)] // size: 16
        public teStructuredDataAssetRef<STUIdentifier> m_A8F4AE5B;
        
        [STUField(0x3400CBD2, 40)] // size: 16
        public teStructuredDataAssetRef<STUIdentifier> m_3400CBD2;
        
        [STUField(0xD2464EEA, 56)] // size: 16
        public teStructuredDataAssetRef<STUMapLayer>[] m_D2464EEA;
        
        [STUField(0xB9BF8121, 72, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 16
        public STU_3F42163E[] m_B9BF8121;
        
        [STUField(0xB414C3DA, 88)] // size: 16
        public teStructuredDataAssetRef<STU_2A60CC09>[] m_B414C3DA;
        
        [STUField(0xF2D8BF6C, 104, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STU_7F3E332A m_F2D8BF6C;
        
        [STUField(0xBA93D5FE, 112)] // size: 12
        public teVec3 m_BA93D5FE;
        
        [STUField(0x62B0C83F, 124)] // size: 12
        public teVec3 m_62B0C83F;
        
        [STUField(0x175A70AB, 136)] // size: 1
        public byte m_175A70AB;
        
        [STUField(0x5A60C16E, 137)] // size: 1
        public byte m_5A60C16E;
        
        [STUField(0xC813DA9D, 138)] // size: 1
        public byte m_C813DA9D;
        
        [STUField(0xDEFCF9DD, 139)] // size: 1
        public byte m_DEFCF9DD;
    }
}
