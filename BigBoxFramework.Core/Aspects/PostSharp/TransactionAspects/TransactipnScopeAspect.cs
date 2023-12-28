using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BigBoxFramework.Core.Aspects.PostSharp
{
    [Serializable]
    public class TransactipnScopeAspect: OnMethodBoundaryAspect
    {
        private TransactionScopeOption _option;

        public TransactipnScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public TransactipnScopeAspect()
        {

        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}
