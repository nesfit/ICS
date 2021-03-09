/**
 * sampler.js is a plugin to display code samples from specially-formatted
 * source files in reveal.js slides.
 *
 * @namespace Sampler
 * @author Louis Dionne
 * @license MIT (https://github.com/ldionne/reveal-sampler/blob/master/LICENSE.md)
 * @see {@link https://github.com/ldionne/reveal-sampler|GitHub} for documentation, bug reports and more.
 */

'use strict';

/**
 * Plugin initialization
 * @function
 */
(function () {

    /**
     * @typedef Sampler.TokenPatterns
     * @property {RegExp} [start] - sample start delimiter pattern
     * @property {RegExp} [end] - sample end delimiter pattern
     * @property {RegExp} [end_named] - sample named end delimiter pattern
     * @property {RegExp} [skip] - skip line pattern
     * @property {RegExp} [mark] - mark line pattern
     */

    /**
     * Match line tokens with a generic and/or language specific patterns
     *
     * @param {Object.<string, Sampler.TokenPatterns>} patterns
     * @constructor
     * @memberof Sampler
     */
    var TokenMatcher = function (patterns) {
        var language, patternName;
        /**
         * @type {Object.<string, Sampler.TokenPatterns>}
         * @private
         */
        this._patterns = {
            generic: {
                start: /^[/*#\s]*sample\(([^)\r\n]+)\)/,
                end_named: /^[/*#\s]*end-sample\(([^)\r\n]+)\)/,
                end: /^[/*#\s]*end-sample/,
                skip: /\bskip-sample\b/,
                mark: /(\s*(\/\/|#)\s*mark-sample\s*$)|(\s*\/\*\s*mark-sample\s*\*\/(\s*$))/
            },
            xml: {
                start: /^\s*<!--\s*sample\(([^)\r\n]+)\)/,
                end_named: /^\s*<!--\s*end-sample\(([^)\r\n]+)\)/,
                end: /^\s*<!--\s*end-sample/,
                skip: /<!--\s*skip-sample\s*-->/,
                mark: /\s*(<!--\s*mark-sample\s*-->\s*$)/
            }
        };
        this._patterns.html = this._patterns.xml;
        if (patterns instanceof Object) {
            for (language in patterns) {
                if (!patterns.hasOwnProperty(language)) {
                    continue;
                }
                for (patternName in TokenMatcher.PATTERN_NAMES) {
                    if (!TokenMatcher.PATTERN_NAMES.hasOwnProperty(patternName)) {
                        continue;
                    }
                    if (patterns[language][patternName] instanceof RegExp) {
                        this._patterns[language][name] = RegExp;
                    } else {
                        console.log('Ignored invalid pattern option for: ' + language + ':' + patternName);
                    }
                }
            }
        }
    };

    /**
     * @typedef {number} Sampler.TokenMatcher.TOKEN
     */

    /**
     * Token identifiers
     *
     * @readonly
     * @enum {Sampler.TokenMatcher.TOKEN}
     */
    TokenMatcher.TOKEN = {
        LINE: 0,
        START_NAMED: 1,
        END: 2,
        END_NAMED: 3,
        SKIP_LINE: 4,
        MARK_LINE: 5
    };

    /**
     * Map token option names to token identifiers
     *
     * @see Sampler.PluginConfiguration
     *
     * @readonly
     * @enum {Sampler.TokenMatcher.TOKEN}
     */
    TokenMatcher.PATTERN_NAMES = {
        start: TokenMatcher.TOKEN.START_NAMED,
        end_named: TokenMatcher.TOKEN.END_NAMED,
        end: TokenMatcher.TOKEN.END,
        skip: TokenMatcher.TOKEN.SKIP_LINE,
        mark: TokenMatcher.TOKEN.MARK_LINE
    };

    /**
     * @param {string} name
     * @param {string} language
     * @returns {RegExp}
     */
    TokenMatcher.prototype.getPattern = function (name, language) {
        if (this._patterns[language] && this._patterns[language][name]) {
            return this._patterns[language][name];
        }
        if (this._patterns.generic && this._patterns.generic[name]) {
            return this._patterns.generic[name];
        }
        throw "Can not find pattern for " + language + ":" + name;
    };

    /**
     * @param {string} subject
     * @param {string} language
     * @returns {?{type:string, match:{}, pattern: RegExp}}
     */
    TokenMatcher.prototype.identify = function (subject, language) {
        var token, pattern, match;
        for (var patternName in TokenMatcher.PATTERN_NAMES) {
            if (!TokenMatcher.PATTERN_NAMES.hasOwnProperty(patternName)) {
                continue;
            }
            token = TokenMatcher.PATTERN_NAMES[patternName];
            pattern = this.getPattern(patternName, language);
            match = subject.match(pattern);
            if (match) {
                return {
                    type: token,
                    match: match,
                    pattern: pattern
                };
            }
        }
        return null;
    };

    /**
     * @param {Number} lineNumber
     * @param {string} text
     * @param {Sampler.TokenMatcher.TOKEN} type
     * @constructor
     * @memberof Sampler
     */
    var Line = function (lineNumber, text, type) {
        /**
         * @type {Number}
         */
        this.lineNumber = lineNumber;
        /**
         * @type {string}
         */
        this.text = text || '';
        /**
         * @type {Sampler.TokenMatcher.TOKEN}
         */
        this.type = type || TokenMatcher.TOKEN.LINE;
    };

    /**
     * SampleFile provides access to the lines and named samples in a file
     *
     * @param {string} content
     * @param {Sampler.TokenMatcher} matcher
     * @param {string} language
     * @constructor
     * @memberof Sampler
     */
    var File = function (content, matcher, language) {
        var lines = content.split(/\r?\n/);
        var line, currentSnippets = [], token, i, c, k;
        var lineType, lineText;

        /**
         * @private
         * @type {Sampler.Line[]}
         */
        this._lines = [];
        /**
         * @private
         * @type {Object.<string, Sampler.Line[]>}
         */
        this._samples = {};

        for (i = 0, c = lines.length; i < c; i++) {
            lineType = TokenMatcher.TOKEN.LINE;
            lineText = lines[i];
            if (i === c - 1 && lineText === '') {
                break;
            }
            token = matcher.identify(lineText, language);
            if (token) {
                lineType = token.type;
                switch (token.type) {
                    case TokenMatcher.TOKEN.START_NAMED :
                        currentSnippets.push(token.match[1]);
                        break;
                    case TokenMatcher.TOKEN.END_NAMED :
                        for (k = currentSnippets.length - 1; k >= 0; k--) {
                            if (currentSnippets[k] === token.match[1]) {
                                currentSnippets.splice(k, 1);
                            }
                        }
                        break;
                    case TokenMatcher.TOKEN.END :
                        if (currentSnippets.length > 0) {
                            currentSnippets.pop();
                        }
                        break;
                    case TokenMatcher.TOKEN.MARK_LINE :
                        lineText = lineText.replace(token.pattern, '');
                        break;
                }
            }
            this._lines.push(
                line = new Line(i + 1, lineText, lineType)
            );
            if (lineType === TokenMatcher.TOKEN.LINE || lineType === TokenMatcher.TOKEN.MARK_LINE) {
                currentSnippets
                    .filter(
                        function (value, index, self) {
                            return self.indexOf(value) === index;
                        }
                    )
                    .forEach(
                        function (index, line) {
                            return function (name) {
                                if (!this._samples.hasOwnProperty(name)) {
                                    this._samples[name] = [];
                                }
                                this._samples[name].push(line);
                            }.bind(this);
                        }.bind(this)(i, line)
                    )
            }
        }
    };

    /**
     * Get an array of lines
     *
     * @param {string} name - sample name
     * @returns {?Sampler.Line[]} - array of sample lines
     */
    File.prototype.getSample = function (name) {
        return this._samples[name] || null;
    };

    /**
     * Get an array of lines specified by start index and length. If
     * length is not provided it will return all following lines.
     *
     * @param {number} [start=0] - start index
     * @param {number} [length] - amount of lines
     * @returns {Sampler.Line[]}
     */
    File.prototype.getLines = function (start, length) {
        start = start > 0 ? start : 0;
        if (typeof length === 'undefined') {
            return this._lines.slice(start);
        }
        return this._lines.slice(start, start + length);
    };

    /**
     * @callback Sampler.Files.FetchSuccess
     * @param {Sampler.File} file
     */

    /**
     * Fetches the files, creates and returns SampleFile objects. It keeps
     * track of requests so that each file is requested once only.
     *
     * @param {Sampler.TokenMatcher} matcher
     * @constructor
     * @memberof Sampler
     */
    var Files = function (matcher) {
        /**
         * @private
         * @type {Sampler.TokenMatcher}
         */
        this._matcher = matcher;
        /**
         * @private
         * @type {Object.<string, Sampler.File>}
         */
        this._files = {};
        /**
         * @private
         * @type {(boolean|Object.<string, {xhr: XMLHttpRequest, success: Sampler.Files.FetchSuccess[]}>)}
         */
        this._requests = {};
    };

    /**
     * Fetch file and execute callback with created SampleFile object
     *
     * @param {string} url
     * @param {string} language
     * @param {Sampler.Files.FetchSuccess} success
     */
    Files.prototype.fetch = function (url, language, success) {
        var file, request;
        file = this._files[url] || null;
        if (file instanceof File) {
            // found existing file object, execute callback
            success(file);
        }
        request = this._requests[url] || null;
        if (request instanceof Object) {
            // found a request. store callback
            request.success.push(success);
        } else if (request === null) {
            // create and store a new request
            this._requests[url] = request = {
                xhr: new XMLHttpRequest(),
                success: [success]
            };
            request.xhr.onreadystatechange = function (url, language, request) {
                return function () {
                    if (request.xhr.readyState === XMLHttpRequest.DONE) {
                        if (
                            (request.xhr.status >= 200 && request.xhr.status < 300) ||
                            (request.xhr.status === 0 && request.xhr.responseText !== '')
                        ) {
                            this._files[url] = file = new File(
                                request.xhr.responseText, this._matcher, language
                            );
                            request.success.forEach(
                                function (file) {
                                    return function (success) {
                                        success(file);
                                    }
                                }(file)
                            );
                            this._requests[url] = true;
                        } else {
                            console.log('Failed to get file: ' + url);
                            this._requests[url] = false;
                        }
                    }
                }.bind(this)
            }.bind(this)(url, language, request);
            request.xhr.open("GET", url);
            try {
                request.xhr.send();
            } catch (e) {
                console.log('Error requesting file: ' + url);
            }
        }
    };

    /**
     * @param {number} start
     * @param {number} length
     * @constructor
     * @memberof Sampler
     */
    var LineRange = function (start, length) {
        /** @type {number} **/
        this.start = start;
        /** @type {number} **/
        this.length = length;
    };

    /**
     * @param {string} name
     * @constructor
     * @memberof Sampler
     */
    var NamedRange = function (name) {
        /** @type {string} **/
        this.name = name;
    };


    /**
     * @constructor
     * @memberof Sampler
     */
    var Sample = function () {
        /** @private */
        this._lines = [];
    };

    /**
     * Create a Sample from a file using a selector
     * @param {Sampler.File} file
     * @param {string} selector
     * @returns {Sampler.Sample}
     */
    Sample.createFromFile = function (file, selector) {
        var sample = new Sample();
        var ranges;
        if (selector) {
            ranges = Sample.parseSelector(selector);
            ranges.forEach(
                function (file) {
                    return function (range) {
                        var lines = null;
                        if (range instanceof LineRange) {
                            lines = file.getLines(range.start, range.length);
                        } else if (range instanceof NamedRange) {
                            lines = file.getSample(range.name);
                        }
                        if (lines) {
                            this.add(lines);
                        }
                    }.bind(this)
                }.bind(sample)(file)
            );
        } else {
            sample.add(file.getLines() || []);
        }
        return sample;
    };

    /**
     * Parse the selector in a list of range objects
     * @param {string} selector
     * @returns {Array.<Sampler.LineRange|Sampler.NamedRange>}
     */
    Sample.parseSelector = function (selector) {
        var ranges = selector.split(",") || [];
        var range, start, end;
        var result = [];
        for (var i = 0, c = ranges.length; i < c; i++) {
            // try to match a line number or range
            range = ranges[i].match(/^\s*(\d+)(?:-(\d+))?\s*$/);
            if (range) {
                start = parseInt(range[1]) || 0;
                end = parseInt(range[2]) || start;
                result.push(new LineRange(start - 1, end - start + 1));
            } else {
                // otherwise treat it as a name
                range = ranges[i].trim();
                if (range !== '') {
                    result.push(new NamedRange(range));
                }
            }
        }
        return result.length > 0 ? result : null;
    };

    /**
     * Expands line numbers and ranges to an object with the line index as key.
     *
     *     3-6,12 => {2: true, 3: true, 4: true, 5: true, 11: true}
     *
     * @param {string} selector
     * @returns {?Object.<number, boolean>}
     */
    Sample.parseSelectorToLineIndex = function (selector) {
        var lines = {};
        var ranges = Sample.parseSelector(selector);
        if (ranges instanceof Array && ranges.length > 0) {
            for (var i = 0, c = ranges.length; i < c; i++) {
                if (ranges[i] instanceof LineRange) {
                    for (var x = 0; x < ranges[i].length; x++) {
                        lines[ranges[i].start + x] = true;
                    }
                }
            }
            return lines;
        }
        return null;
    };

    /**
     * @param {Sampler.Line[]} lines
     */
    Sample.prototype.add = function (lines) {
        this._lines.push.apply(
            this._lines,
            lines.filter(
                function (line) {
                    return line.type !== TokenMatcher.TOKEN.SKIP_LINE;
                }
            )
        );
    };

    /**
     * @param {boolean} skipDelimiters
     * @param {number[]} skipLines - skip lines by index
     * @returns {Sampler.Line[]}
     */
    Sample.prototype.getLines = function (skipDelimiters, skipLines) {
        var lines = this._lines;
        if (skipDelimiters) {
            lines = lines.filter(
                function (line) {
                    // skip delimiter lines if option is set
                    return !(
                        skipDelimiters &&
                        (
                            line.type === TokenMatcher.TOKEN.START_NAMED ||
                            line.type === TokenMatcher.TOKEN.END ||
                            line.type === TokenMatcher.TOKEN.END_NAMED
                        )
                    );
                }
            )
        }
        if (skipLines) {
            lines = lines.filter(
                function (line, index) {
                    // skip lines defined by index
                    return !skipLines[index];
                }
            )
        }
        return lines;
    };

    /**
     * @typedef Sampler.Sample.AppendOptions
     * @property {boolean} removeIndentation
     * @property {string} marked
     * @property {(boolean|number|'original')} lineNumbers
     * @property {Object} skip
     */

    /**
     * @param {HTMLElement} parentNode
     * @param {Sampler.Sample.AppendOptions} options
     * @returns {void}
     */
    Sample.prototype.appendTo = function (parentNode, options) {
        var line, lineNode, previousLineNode, lineText = null;
        var document = parentNode.ownerDocument;
        var marked = Sample.parseSelectorToLineIndex(options.marked || '') || {};
        var lineNumberStart = parseInt(options.lineNumbers) || 0, lineNumberSize;
        var lines = this.getLines(options.skip.delimiters, options.skip.lines);
        var indentationOffset = (options.removeIndentation) ? this.getIndentationLength(lines) : 0;
        if (lines.length < 1) {
            return;
        }
        if (options.lineNumbers === true || options.lineNumbers === 'true' || options.lineNumbers === 'yes') {
            lineNumberStart = 1;
        }
        if (options.lineNumbers === 'original') {
            lineNumberSize = lines[lines.length - 1].lineNumber.toString().length;
        } else {
            lineNumberSize = (lineNumberStart + this._lines.length).toString().length;
        }
        parentNode.setAttribute('data-noescape', '');
        for (var i = 0, c = lines.length; i < c; i++) {
            line = lines[i];
            lineText = line.text.substr(indentationOffset);
            lineNode = parentNode.appendChild(document.createElement('span'));
            lineNode.setAttribute('class', 'line');
            if (options.lineNumbers === 'original') {
                // noinspection JSUnresolvedFunction
                lineNode.setAttribute('data-line-number', String(line.lineNumber).padStart(lineNumberSize));
            } else if (lineNumberStart > 0) {
                // noinspection JSUnresolvedFunction
                lineNode.setAttribute('data-line-number', String(lineNumberStart + i).padStart(lineNumberSize));
            }
            if (line.type === TokenMatcher.TOKEN.MARK_LINE || marked[i]) {
                lineNode
                    .appendChild(document.createElement('mark'))
                    .appendChild(document.createTextNode(lineText));
            } else {
                lineNode.appendChild(document.createTextNode(lineText));
            }
            if (previousLineNode) {
                previousLineNode.appendChild(document.createTextNode('\n'));
            }
            previousLineNode = lineNode;
        }
    };

    /**
     * Get the length of the shortest whitespace sequence at a line start
     *
     * @param {Sampler.Line[]} [lines]
     * @returns {number}
     */
    Sample.prototype.getIndentationLength = function (lines) {
        lines = lines instanceof Array ? lines : this._lines;
        return Math.min.apply(
            null,
            lines
                .filter(
                    function (line) {
                        return line.text.trim() !== '';
                    }
                )
                .map(
                    function (line) {
                        var indentation = line.text.match(/^[ \t]+/);
                        return indentation ? indentation[0].length : 0
                    }
                )
        ) || 0;
    };

    /**
     * @typedef Sampler.PluginConfiguration
     *
     * @property {boolean} [removeIndentation] - remove indentation (un-indent source snippet)
     * @property {(boolean|'original')} [lineNumbers] - show line numbers
     * @property {(string|string[])} [skip] - skip specific lines by time (delimiter)
     * @property {string} [proxyURL] - fetch source files using a proxy script
     * @property {Object.<string, Sampler.TokenPatterns>} [patterns] - language specific patterns
     */

    Reveal.addEventListener('ready', event => {
        /**
         * Read sampler plugin options from reveal.js configuration
         * @type {{?sampler: Sampler.PluginConfiguration}}
         */
        var config = Reveal.getConfig() || {};
        config.sampler = config.sampler || {};

        /**
         * @type {Sampler.PluginConfiguration}
         */
        var options = {
            removeIndentation: !!config.sampler.removeIndentation,
            lineNumbers: [true, 'original'].indexOf(config.sampler.lineNumbers) !== -1
                ? config.sampler.lineNumbers : false,
            skip: config.sampler.skip instanceof Array
                ? config.sampler.skip : (config.sampler.skip || '').split(/[,\s]+/),
            proxyURL: config.sampler.proxyURL || '',
            patterns: config.sampler.patterns || null
        };

        (function () {
            // add some CSS to make the line numbers visible
            var style =
                "[data-sample] [data-line-number]:before {\n" +
                "   content: attr(data-line-number) ': ';\n" +
                "}";
            var styleNode = document.createElement('style');
            styleNode.setAttribute('type', 'text/css');
            styleNode.appendChild(document.createTextNode(style));
            document.head.appendChild(styleNode);
        })();

        var files = new Files(new TokenMatcher(options.patterns));
        var elements = document.querySelectorAll('[data-sample]');
        elements.forEach(
            /**
             *
             * @param {HTMLElement} element
             */
            function (element) {
                var slug = element.getAttribute('data-sample').match(/([^#]+)(?:#(.+))?/);
                var url = options.proxyURL + slug[1];
                var selector = slug[2] || '';

                // Add the right `language-xyz` class to the code block, if required.
                var language = url.split('.').pop().toLowerCase();
                var classString = element.getAttribute('class') || '';
                var classMatch = classString.match(/(?:^|\s)lang(?:uage)?-([a-z\d]+)/);
                if (classMatch) {
                    language = classMatch[1];
                } else {
                    element.setAttribute('class', classString + ' language-' + language);
                }

                files.fetch(
                    url,
                    language,
                    function (sampleFile) {
                        var sample = Sample.createFromFile(sampleFile, selector);
                        var attributes = {
                            mark: element.getAttribute('data-sample-mark') || '',
                            indent: element.getAttribute('data-sample-indent'),
                            skip: (element.getAttribute('data-sample-skip') || options.skip.join(',')),
                            lineNumbers: element.getAttribute('data-sample-line-numbers')
                        };

                        sample.appendTo(
                            element,
                            {
                                // marked lines selector
                                marked: attributes.mark,
                                // skip lines
                                skip: {
                                    // (sample start/end) delimiter lines)
                                    delimiters: attributes.skip.match(/\bdelimiters?\b/),
                                    // expand ranges to line index array
                                    lines: Sample.parseSelectorToLineIndex(attributes.skip)
                                },
                                // indentation behaviour defined by attribute or global option
                                removeIndentation:
                                    attributes.indent === 'remove' ||
                                    (options.removeIndentation && attributes.indent !== 'keep'),
                                // line numbers behaviour
                                lineNumbers: attributes.lineNumbers || options.lineNumbers
                            }
                        );
                        if (typeof RevealHighlight.apply().hljs !== 'undefined') {
                            RevealHighlight.apply().hljs.highlightBlock(element);
                        }
                    }
                );
            }
        );
    });
})();