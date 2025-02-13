﻿using System;
using System.Security;
using System.Text.RegularExpressions;
using mRemoteNG.Resources.Language;

namespace mRemoteNG.Security.PasswordCreation
{
    public class PasswordIncludesLowerCaseConstraint : IPasswordConstraint
    {
        private readonly int _minimumCount;

        public string ConstraintHint { get; }

        public PasswordIncludesLowerCaseConstraint(int minimumCount = 1)
        {
            if (minimumCount < 0)
                throw new ArgumentException($"{nameof(minimumCount)} must be a positive value");

            _minimumCount = minimumCount;
            ConstraintHint = string.Format(Language.PasswordContainsLowerCaseConstraintHint, _minimumCount);
        }

        public bool Validate(SecureString password)
        {
            Regex regex = new(@"[a-z]");
            return regex.Matches(password.ConvertToUnsecureString()).Count >= _minimumCount;
        }
    }
}