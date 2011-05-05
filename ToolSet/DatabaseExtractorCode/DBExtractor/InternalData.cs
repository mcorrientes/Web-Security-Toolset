namespace ToolSet.DatabaseExtractorCode.DBExtractor
{
   public enum DataBaseType
   {
      Mssql,
      MySql,
      Unknown
   }
   public class InternalData
   {
      public bool Prepared;
      public bool ParameterInjectable;
      public string InjectableCondition;
      public string InjectableBegin;
      public string InjectableEnd;
      public DataBaseType DataBaseType;
      public bool UseConditions;

      public InternalData()
      {
         Prepared = false;
         ParameterInjectable = false;
         InjectableCondition = string.Empty;
         InjectableBegin = string.Empty;
         InjectableEnd = string.Empty;
         DataBaseType = DataBaseType.Unknown;
         UseConditions = true;
      }
   }
}
