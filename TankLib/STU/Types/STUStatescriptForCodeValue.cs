// Instance generated by TankLibHelper.InstanceBuilder

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0x62562540, "STUStatescriptForCodeValue")]
    public class STUStatescriptForCodeValue : STUInstance {
        [STUFieldAttribute(0x4D2DB658, "m_identifier")]
        public teStructuredDataAssetRef<STUIdentifier> m_identifier;

        [STUFieldAttribute(0x07DD813E, "m_value", ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STUConfigVar m_value;
    }
}
