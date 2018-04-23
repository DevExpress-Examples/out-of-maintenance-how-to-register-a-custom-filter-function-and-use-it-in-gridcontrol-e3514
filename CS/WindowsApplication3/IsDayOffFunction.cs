using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.Data.Filtering;

namespace DXSample {
    public class IsDayOffFunction : ICustomFunctionOperatorBrowsable { 
        const string FunctionName = "IsDayOff";
        static readonly IsDayOffFunction instance = new IsDayOffFunction();

        public static void Register()
        {
            CriteriaOperator.RegisterCustomFunction(instance);
        }
        public static bool Unregister()
        {
            return CriteriaOperator.UnregisterCustomFunction(instance);
        }

        #region ICustomFunctionOperatorBrowsable Members

        public FunctionCategory Category
        {
            get {return FunctionCategory.DateTime; }
        }

        public string Description
        {
            get { return "IsDayOff"; }
        }

        public bool IsValidOperandCount(int count)
        {
           return count == 1;
        }

        public bool IsValidOperandType(int operandIndex, int operandCount, Type type)
        {
            return type == typeof(DateTime);
        }

        public int MaxOperandCount
        {
            get { return 1; }
        }

        public int MinOperandCount
        {
            get { return 1; }
        }

        #endregion

        #region ICustomFunctionOperator Members

        public object Evaluate(params object[] operands)
        {
            DateTime dt = Convert.ToDateTime(operands[0]);
            return dt.DayOfWeek == DayOfWeek.Sunday || dt.DayOfWeek == DayOfWeek.Saturday;
        }

        public string Name
        {
            get { return FunctionName; }
        }

        public Type ResultType(params Type[] operands)
        {
            return typeof(bool);
        }

        #endregion
    }
}