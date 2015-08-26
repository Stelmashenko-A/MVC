﻿using System;
using System.Transactions;
using PostSharp.Aspects;

namespace MVC.AOP
{
    [Serializable]
    public class TransactionAspect : OnMethodBoundaryAspect
    {
        [NonSerialized]
        private TransactionScope _transactionScope;

        public override void OnEntry(MethodExecutionArgs args)
        {
            _transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _transactionScope.Complete();
        }

        public override void OnException(MethodExecutionArgs args)
        {
            args.FlowBehavior = FlowBehavior.Continue;
            Transaction.Current.Rollback();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            _transactionScope.Dispose();
        }
    }
}