﻿// 
//  Copyright 2017 Gustavo J Knuppe (https://github.com/knuppe)
// 
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
// 
//       http://www.apache.org/licenses/LICENSE-2.0
// 
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// 
//   - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
//   - May you do good and not evil.                                         -
//   - May you find forgiveness for yourself and forgive others.             -
//   - May you share freely, never taking more than you give.                -
//   - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
//  

using System.Text.RegularExpressions;

namespace SharpNL.Utility.Normalizer {
    /// <summary>
    /// Normalizer that removes URls and email addresses.
    /// </summary>
    /// <inheritdoc />
    public class UrlStringNormalizer : IStringNormalizer {

        private static UrlStringNormalizer instance;

        private static readonly Regex UrlRegex = new Regex("https?://[-_.?&~;+=/#0-9A-Za-z]+", RegexOptions.Compiled);
        private static readonly Regex EmailRegex = new Regex("[-_.0-9A-Za-z]+@[-_0-9A-Za-z]+[-_.0-9A-Za-z]+", RegexOptions.Compiled);

        /// <summary>
        /// Gets the static instance of <see cref="UrlStringNormalizer"/>.
        /// </summary>
        public static UrlStringNormalizer Instange => instance ?? (instance = new UrlStringNormalizer());

        /// <inheritdoc />
        public string Normalize(string text) {
            return string.IsNullOrEmpty(text) ? text : EmailRegex.Replace(UrlRegex.Replace(text, " "), " ");
        }
    }
}
