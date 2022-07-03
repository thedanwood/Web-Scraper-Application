using EnumsNET;
using SearchEngineKeywordTracker.DataAccessLayer.Interfaces;
using SearchEngineKeywordTracker.DataAccessLayer.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchEngineKeywordTracker.Domain.BusinessLogic;
using System.Text.RegularExpressions;

namespace SearchEngineKeywordTracker.Domain.Validation
{
    public class CustomValidation
    {
        private readonly ISearchEngineRepository _searchEngineRepository;
        public CustomValidation(ISearchEngineRepository searchEngineRepository)
        {
            _searchEngineRepository = searchEngineRepository;
        }
        public static bool StringLengthIsValid(string value, int minLength, int maxLength, bool allowNulls)
        {
            bool stringNullCheckValid = allowNulls ? true : value == null;
            if (stringNullCheckValid || value.Length > maxLength || value.Length < minLength)
                return false;
            return true;
        }
        public static ValidationResult ReturnInvalidResult(string message)
        {
            return new ValidationResult(message);
        }
        public static ValidationResult ReturnValidResult(string message = null)
        {
            return ValidationResult.Success;
        }
        public class SearchEngineTypeListValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if(value == null)
                {
                    return ReturnInvalidResult("You must select a search engine from the list.");
                }
                var searchEngineTypeList = value as IEnumerable<int>;
                bool isValid = true;
                foreach (var searchEngineType in searchEngineTypeList)
                {
                    bool doesExist =/* _searchEngineRepository.DoesSearchEngineTypeExistAsync(searchEngineType);*/ true;
                    if (!doesExist)
                        isValid = false;
                }

                if (isValid == false)
                {
                    return ReturnInvalidResult("Oops. You chose a search engine that's not allowed! Pick another one.");
                }
                return ReturnValidResult();
            }
        }
        public class SearchKeywordListValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value == null)
                {
                    return ReturnInvalidResult("You must enter at least 1 keyword.");
                }
                var searchKeywordList = value as List<string>;
                if (searchKeywordList.Count() > 25)
                {
                    return ReturnInvalidResult("You must enter less than 26 keywords at a time.");
                }
                bool isValid = true;
                foreach (var searchKeyword in searchKeywordList)
                {
                    if(!StringLengthIsValid(searchKeyword.ToString(), 1, 200, false))
                        isValid = false;
                }
                if (isValid == false)
                {
                    return ReturnInvalidResult("Your keyword(s) must be between 1 and 200 characters");
                }
                return ReturnValidResult();
            }
        }
        public class SearchUrlValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value == null)
                {
                    return ReturnInvalidResult("You must enter a Url.");
                }
                string searchUrl = value.ToString();
                Regex regex = new Regex(@"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$", RegexOptions.IgnoreCase);
                bool urlIsValid = regex.IsMatch(searchUrl);
                if (!urlIsValid)
                {
                    return ReturnInvalidResult("Your Url must be in a valid format such as: www.google.com or http://www.google.com");
                }
                if (!StringLengthIsValid(searchUrl, 5, 500, false))
                {
                    return ReturnInvalidResult("Your Url must be between 5 and 500 characters.");
                }
                return ReturnValidResult();
            }
        }
    }
}
