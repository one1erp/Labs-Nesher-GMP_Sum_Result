//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Common;
//using LSEXT;
//using LSSERVICEPROVIDERLib;
//using System.Runtime.InteropServices;

//namespace WaterResultExtension
//{

//    [ComVisible(true)]
//    [ProgId("GMP_Sum_Result.GMP_Sum_WF_ResultCls")]
//    public class GMP_Sum_WF_ResultCls : IWorkflowExtension
//    {

//        private const string SumResultName = "Copy of Summary - Coefficient of Variance";
//        public void Execute(ref LSExtensionParameters Parameters)
//        {
//            try
//            {
//                Logger.WriteLogFile("start WaterResultExtension ", false);
//                INautilusServiceProvider sp = Parameters["SERVICE_PROVIDER"];

//                Logger.WriteLogFile("INautilusServiceProvider load ", false);


//                var ntlsCon = Utils.GetNtlsCon(sp);
//                Logger.WriteLogFile("ntlsCon ", false);

//                Utils.CreateConstring(ntlsCon);
//                Logger.WriteLogFile("CreateConstring creatred ", false);



//                var dal = new DataLayer();
//                dal.Connect();

//                Logger.WriteLogFile("connected to dal", false);

//                var rs = Parameters["RECORDS"];

//                double resultId = rs.Fields["RESULT_ID"].Value;

//                Logger.WriteLogFile("resultId is " + resultId, false);
//                Result res = dal.GetResultById((long)resultId);
//                var description = res.Test.Aliquot.Description;
//                Logger.WriteLogFile("description is ", false);
//                var sr = res.Test.Results.Where(r => r.Name == SumResultName);
//                var r1 = sr.First();
//                r1.FormattedResult = description;
//                dal.SaveChanges();
//                dal.Close();



//            }
//            catch (COMException exception)
//            {
//                Logger.WriteLogFile(exception);




//            }
//        }
//    }
//}