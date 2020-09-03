﻿using System;
using System.Reflection;

namespace Rougamo.Context
{
    /// <summary>
    /// 方法执行上下文共享部分
    /// </summary>
    public sealed class MethodContext
    {
        private Exception _exception;
        private bool _hasException;
        private bool _exceptionSet;
        private object _returnValue;
        private bool _hasReturnValue;
        private bool _returnValueSet;

        /// <summary>
        /// </summary>
        public MethodContext(object target, Type targetType, MethodBase method, object[] args)
        {
            Target = target;
            TargetType = targetType;
            Method = method;
            Arguments = args;
        }

        /// <summary>
        /// 宿主类实例
        /// </summary>
        public object Target { get; private set; }

        /// <summary>
        /// 宿主类型
        /// </summary>
        public Type TargetType { get; set; }

        /// <summary>
        /// 方法入参
        /// </summary>
        public object[] Arguments { get; private set; }

        /// <summary>
        /// 切入方法
        /// </summary>
        public MethodBase Method { get; private set; }

        /// <summary>
        /// 异常，不可修改，静态织入时设置
        /// </summary>
        public Exception Exception
        {
            get => _exception;
            set
            {
                if (_exceptionSet) return;
                _exceptionSet = true;
                _hasException = true;
                _exception = value;
            }
        }

        /// <summary>
        /// 是否有异常，不可修改，静态织入时设置
        /// </summary>
        public bool HasException
        {
            get => _hasException;
            set
            {
                if (_exceptionSet) return;
                _exceptionSet = true;
                _hasException = value;
            }
        }

        /// <summary>
        /// 方法返回值，不可修改，静态织入时设置
        /// </summary>
        public object ReturnValue
        {
            get => _returnValue;
            set
            {
                if (_returnValueSet) return;
                _returnValueSet = true;
                _hasReturnValue = true;
                _returnValue = value;
            }
        }

        /// <summary>
        /// 是否有返回值，不可修改，静态织入时设置
        /// </summary>
        public bool HasReturnValue
        {
            get => _hasReturnValue;
            set
            {
                if (_returnValueSet) return;
                _returnValueSet = true;
                _hasReturnValue = value;
            }
        }
    }
}
