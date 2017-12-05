using System;
using System.Collections.Generic;
using System.Linq;
using Dacsa.Data.Entities.Objects;
using Dacsa.Framework.Shared.Interfaces;

namespace Bold.WebAPI.Commons.Helpers
{
    public class LanguageHelper
    {
        private readonly IReadOnlyCollection<Language> _languages;

        public LanguageHelper() : this(ServiceHelper.GetIServerServiceWrapper()) {}

        public LanguageHelper(ICommonService server)
        {
            _languages = server?.GetAllLanguages().ToList().AsReadOnly() ?? throw new ArgumentNullException(nameof(server));
        }

        public bool LanguageExists(string locale)
        {
            return _languages.Any(l => l.LocaleShort == locale);
        }

        public bool LanguageExists(int languageId)
        {
            return _languages.Any(l => l.Id == languageId);
        }

        public int GetLanguageId(string locale)
        {
            var language = _languages.FirstOrDefault(l => l.LocaleShort == locale);
            return language.Id;
        }

        public List<int> GetAllLanguageIds()
        {
            return _languages.Select(l => l.Id).ToList();
        }

        public string GetLanguageLocale(int languageId)
        {
            var language = _languages.FirstOrDefault(l => l.Id == languageId);
            return language?.LocaleShort;
        }

        public List<string> GetAllLanguageLocales()
        {
            return _languages.Select(l => l.LocaleShort).ToList();
        }
    }
}
