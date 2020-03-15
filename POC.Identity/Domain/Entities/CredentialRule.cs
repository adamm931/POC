using POC.Common.Domain;
using POC.Identity.Common;
using POC.Identity.Domain.Enums;
using POC.Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace POC.Identity.Domain.Entities
{
    public abstract class CredentialRule : Entity
    {
        #region Base

        public CredentialRuleType RuleType { get; private set; }

        public CredentialType CredentialType { get; private set; }

        public ICollection<CredentialRuleAttribute> Attributes { get; private set; }

        public abstract CredentialRuleValidationResult Validate(string input);

        protected CredentialRuleAttribute GetAttribute(string name)
        {
            return Attributes
                .Where(attr => attr.IsEnabled)
                .FirstOrDefault(attr => attr.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public CredentialRule(
            CredentialType credentialType,
            CredentialRuleType ruleType,
            params CredentialRuleAttribute[] attributes) : this(ruleType)
        {
            CredentialType = credentialType;
            Attributes = attributes;
        }

        protected CredentialRule(CredentialRuleType ruleType) : this()
        {
            RuleType = ruleType;
        }

        protected CredentialRule() { }

        #endregion

        #region MinimumLenght

        public class MinimumLenghtRule : CredentialRule
        {
            public MinimumLenghtRule(CredentialType credentialType, params CredentialRuleAttribute[] attributes)
                : base(credentialType, CredentialRuleType.MinimumLenght, attributes)
            {
            }

            private MinimumLenghtRule() : base(CredentialRuleType.MinimumLenght)
            {
            }

            public override CredentialRuleValidationResult Validate(string input)
            {
                var minimumLenghtAttr = GetAttribute(RuleType);
                var minimumLenght = Convert.ToInt32(minimumLenghtAttr.Value);

                if (input.Length < minimumLenght)
                {
                    return CredentialRuleValidationResult.Error($"The lenght must be greather or equal than {minimumLenght}");
                }

                return CredentialRuleValidationResult.Valid();
            }
        }

        #endregion

        #region RequireAlphaNumeric

        public class RequireAlphaNumericCharathersRule : CredentialRule
        {
            public RequireAlphaNumericCharathersRule(CredentialType credentialType, params CredentialRuleAttribute[] attributes)
                : base(credentialType, CredentialRuleType.RequireAlphaNumeric, attributes)
            {
            }

            private RequireAlphaNumericCharathersRule() : base(CredentialRuleType.RequireAlphaNumeric)
            {
            }

            public override CredentialRuleValidationResult Validate(string input)
            {
                if (!Regex.IsMatch(input, IdentityDefaults.RegularExpressions.Master))
                {
                    return CredentialRuleValidationResult.Error("It must contain alpha numeric charathers");
                }

                return CredentialRuleValidationResult.Valid();
            }
        }

        #endregion

        #region RequireSpecialCharater

        public class RequireSpecialCharathersRule : CredentialRule
        {
            public RequireSpecialCharathersRule(CredentialType credentialType, params CredentialRuleAttribute[] attributes)
                : base(credentialType, CredentialRuleType.RequireSpecialCharater, attributes)
            {
            }

            private RequireSpecialCharathersRule() : base(CredentialRuleType.RequireSpecialCharater)
            {
            }

            public override CredentialRuleValidationResult Validate(string input)
            {
                if (!input.Any(c => !char.IsLetterOrDigit(c)))
                {
                    return CredentialRuleValidationResult.Error($"It must contain special charather");
                }

                return CredentialRuleValidationResult.Valid();
            }
        }

        #endregion
    }
}
