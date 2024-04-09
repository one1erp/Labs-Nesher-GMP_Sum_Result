using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using LSEXT;
using LSSERVICEPROVIDERLib;
using System.Runtime.InteropServices;

namespace WaterResultExtension
{

    [ComVisible(true)]
    [ProgId("GMP_Sum_Result.GMP_Sum_RF_ResultCls")]
    public class GMP_Sum_RF_ResultCls : IResultFormat
    {

        private const string SumResultName = "Copy of Summary - Coefficient of Variance";


        public ResultEntryFormat Format(ref LSExtensionParameters Parameters, ResultEntryPhase Phase)
        {
            try
            {

                var original_result = Parameters.Parameter("original_result").Value;
                Logger.WriteLogFile("original_result  " + original_result, false);

                if (original_result == "0")
                {
                    var description = Parameters.Parameter("description").Value;
                    Logger.WriteLogFile("description  " + description, false);

                    Parameters.Parameter("formatted_result").Value = description;
                }
                else
                {
                    var originalResultValue = Parameters.Parameter("original_result").Value;
                    Logger.WriteLogFile("original_result  " + originalResultValue, false);

                    Parameters.Parameter("formatted_result").Value = originalResultValue;

                }

                return LSEXT.ResultEntryFormat.rfSkipDefault;





            }
            catch (Exception ex)
            {
                Logger.WriteLogFile(ex);
            }
            return LSEXT.ResultEntryFormat.rfDoDefault;
        }

        public ResultFieldChange FieldChange(ref LSExtensionParameters Parameters)
        {
            return LSEXT.ResultFieldChange.rcAllow;
        }
    }
}