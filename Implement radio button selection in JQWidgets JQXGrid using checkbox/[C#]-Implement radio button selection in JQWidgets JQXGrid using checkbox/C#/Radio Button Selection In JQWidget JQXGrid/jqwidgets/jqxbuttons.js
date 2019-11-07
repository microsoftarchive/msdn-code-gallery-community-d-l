/*
jQWidgets v4.1.2 (2016-Apr)
Copyright (c) 2011-2016 jQWidgets.
License: http://jqwidgets.com/license/
*/

(function ($) {
    $.jqx.cssroundedcorners = function (value) {
        var cssMap = {
            'all': 'jqx-rc-all',
            'top': 'jqx-rc-t',
            'bottom': 'jqx-rc-b',
            'left': 'jqx-rc-l',
            'right': 'jqx-rc-r',
            'top-right': 'jqx-rc-tr',
            'top-left': 'jqx-rc-tl',
            'bottom-right': 'jqx-rc-br',
            'bottom-left': 'jqx-rc-bl'
        };

        for (prop in cssMap) {
            if (!cssMap.hasOwnProperty(prop))
                continue;

            if (value == prop)
                return cssMap[prop];
        }
    }

    $.jqx.jqxWidget("jqxButton", "", {});

    $.extend($.jqx._jqxButton.prototype, {
        defineInstance: function () {
            var settings = {
                cursor: 'arrow',
                // rounds the button corners.
                roundedCorners: 'all',
                // enables / disables the button
                disabled: false,
                // sets height to the button.
                height: null,
                // sets width to the button.
                width: null,
                overrideTheme: false,
                enableHover: true,
                enableDefault: true,
                enablePressed: true,
                imgPosition: "center",
                imgSrc: "",
                imgWidth: 16,
                imgHeight: 16,
                value: null,
                textPosition: "",
                textImageRelation: "overlay",
                rtl: false,
                _ariaDisabled: false,
                _scrollAreaButton: false,
                // "primary", "inverse", "danger", "info", "success", "warning", "link"
                template: "default",
                aria:
                {
                    "aria-disabled": { name: "disabled", type: "boolean" }
                }
           }
            $.extend(true, this, settings);
            return settings;
        },

        _addImage: function (name)
        {
            var that = this;
            if (that.element.nodeName.toLowerCase() == "input" || that.element.nodeName.toLowerCase() == "button" || that.element.nodeName.toLowerCase() == "div")
            {
                if (!that._img) {
                    that.field = that.element;
                    if (that.field.className) {
                        that._className = that.field.className;
                    }

                    var properties = {
                        'title': that.field.title
                    };

                    var value = null;
                    if (that.field.getAttribute('value')) {
                        var value = that.field.getAttribute('value');
                    }
                    else if (that.element.nodeName.toLowerCase() != "input")
                    {
                        var value = that.element.innerHTML;
                    }
                    if (that.value)
                    {
                        value = that.value;
                    }
                    if (that.field.id.length) {
                        properties.id = that.field.id.replace(/[^\w]/g, '_') + "_" + name;
                    }
                    else {
                        properties.id = $.jqx.utilities.createId() + "_" + name;
                    }


                    var wrapper = $("<div></div>", properties);


                    wrapper[0].style.cssText = that.field.style.cssText;
                    wrapper.css('box-sizing', 'border-box');

                    var img = $("<img/>");
                    img[0].setAttribute('src', that.imgSrc);
                    img[0].setAttribute('width', that.imgWidth);
                    img[0].setAttribute('height', that.imgHeight);
                    wrapper.append(img);
                    that._img = img;

                    var text = $("<span></span>");
                    if (value) {
                        text.html(value);
                        that.value = value;
                    }
                    wrapper.append(text);
                    that._text = text;

                    $(that.field).hide().after(wrapper);
                    var data = that.host.data();
                    that.host = wrapper;
                    that.host.data(data);
                    that.element = wrapper[0];
                    that.element.id = that.field.id;
                    that.field.id = properties.id;
                    if (that._className) {
                        that.host.addClass(that._className);
                        $(that.field).removeClass(that._className);
                    }

                    if (that.field.tabIndex) {
                        var tabIndex = that.field.tabIndex;
                        that.field.tabIndex = -1;
                        that.element.tabIndex = tabIndex;
                    }
                }
                else {
                    that._img[0].setAttribute('src', that.imgSrc);
                    that._img[0].setAttribute('width', that.imgWidth);
                    that._img[0].setAttribute('height', that.imgHeight);
                    that._text.html(that.value);
                }
                if (!that.imgSrc)
                {
                    that._img.hide();
                }
                else
                {
                    that._img.show();
                }

                if (!that.value)
                {
                    that._text.hide();
                }
                else
                {
                    that._text.show();
                }

                that._positionTextAndImage();
            }
        },

        _positionTextAndImage: function()
        {
            var that = this;
            var width = that.host.outerWidth();
            var height = that.host.outerHeight();

            var imgWidth = that.imgWidth;
            var imgHeight = that.imgHeight;
            if (that.imgSrc == "") {
                imgWidth = 0;
                imgHeight = 0;
            }

            var textWidth = that._text.width();
            var textHeight = that._text.height();
            var offset = 4;
            var edgeOffset = 4;
            var factorIncrease = 4;
            var w = 0;
            var h = 0;
            switch (that.textImageRelation) {
                case "imageBeforeText":
                case "textBeforeImage":
                    w = imgWidth + textWidth + 2 * factorIncrease + offset + 2 * edgeOffset;
                    h = Math.max(imgHeight, textHeight) + 2 * factorIncrease + offset + 2 * edgeOffset;
                    break;
                case "imageAboveText":
                case "textAboveImage":
                    w = Math.max(imgWidth, textWidth) + 2 * factorIncrease;
                    h = imgHeight + textHeight + offset + 2 * factorIncrease + 2 * edgeOffset;
                    break;
                case "overlay":
                    w = Math.max(imgWidth, textWidth) + 2 * factorIncrease;
                    h = Math.max(imgHeight, textHeight) + 2 * factorIncrease;
                    break;
            }

            if (!that.width) {
                that.host.width(w);
                width = w;
            }

            if (!that.height) {
                that.host.height(h);
                height = h;
            }

            that._img.css('position', 'absolute');
            that._text.css('position', 'absolute');
            that.host.css('position', 'relative');
            that.host.css('overflow', 'hidden');

            var textRect = {};
            var imageRect = {};

            var drawElement = function (element, drawArea, pos, w, h) {
                if (drawArea.width < w) drawArea.width = w;
                if (drawArea.height < h) drawArea.height = h;

                switch (pos) {
                    case "left":
                        element.style.left = drawArea.left + "px";
                        element.style.top = drawArea.top + drawArea.height / 2 - h / 2 + "px";;
                        break;
                    case "topLeft":
                        element.style.left = drawArea.left + "px";
                        element.style.top = drawArea.top + "px";
                        break;
                    case "bottomLeft":
                        element.style.left = drawArea.left + "px";
                        element.style.top = drawArea.top + drawArea.height - h + "px";
                        break;
                    default:
                    case "center":
                        element.style.left = drawArea.left + drawArea.width / 2 - w / 2 + "px";
                        element.style.top = drawArea.top + drawArea.height / 2 - h / 2 + "px";
                        break;
                    case "top":
                        element.style.left = drawArea.left + drawArea.width / 2 - w / 2 + "px";
                        element.style.top = drawArea.top + "px";
                        break;
                    case "bottom":
                        element.style.left = drawArea.left + drawArea.width / 2 - w / 2 + "px";
                        element.style.top = drawArea.top + drawArea.height - h + "px";
                        break;
                    case "right":
                        element.style.left = drawArea.left + drawArea.width - w + "px";
                        element.style.top = drawArea.top + drawArea.height / 2 - h / 2 + "px";;
                        break;
                    case "topRight":
                        element.style.left = drawArea.left + drawArea.width - w + "px";
                        element.style.top = drawArea.top + "px";
                        break;
                    case "bottomRight":
                        element.style.left = drawArea.left + drawArea.width - w + "px";
                        element.style.top = drawArea.top + drawArea.height - h + "px";
                        break;
                }
            }

            var left = 0;
            var top = 0;
            var right = width;
            var bottom = height;
            var middle = (right - left) / 2;
            var center = (bottom - top) / 2;
            var img = that._img;
            var text = that._text;
            var rectHeight = bottom - top;
            var rectWidth = right - left;
            left += edgeOffset;
            top += edgeOffset;
            right = right - edgeOffset - 2;
            rectWidth = rectWidth - 2 * edgeOffset - 2;
            rectHeight = rectHeight - 2 * edgeOffset - 2;

            switch (that.textImageRelation) {
                case "imageBeforeText":

                    switch (that.imgPosition) {
                        case "left":
                        case "topLeft":
                        case "bottomLeft":
                            imageRect = { left: left, top: top, width: left + imgWidth, height: rectHeight };
                            textRect = { left: left + imgWidth + offset, top: top, width: rectWidth - imgWidth - offset, height: rectHeight };
                            break;
                        case "center":
                        case "top":
                        case "bottom":
                            imageRect = { left: middle - textWidth / 2 - imgWidth / 2 - offset / 2, top: top, width: imgWidth, height: rectHeight };
                            textRect = { left: imageRect.left + imgWidth + offset, top: top, width: right - imageRect.left - imgWidth - offset, height: rectHeight };
                            break;
                        case "right":
                        case "topRight":
                        case "bottomRight":
                            imageRect = { left: right - textWidth - imgWidth - offset, top: top, width: imgWidth, height: rectHeight };
                            textRect = { left: imageRect.left + imgWidth + offset, top: top, width: right - imageRect.left - imgWidth - offset, height: rectHeight };
                            break;

                    }
                    drawElement(img[0], imageRect, that.imgPosition, imgWidth, imgHeight);
                    drawElement(text[0], textRect, that.textPosition, textWidth, textHeight);
         
                    break;
                case "textBeforeImage":

                    switch (that.textPosition) {
                        case "left":
                        case "topLeft":
                        case "bottomLeft":
                            textRect = { left: left, top: top, width: left + textWidth, height: rectHeight };
                            imageRect = { left: left + textWidth + offset, top: top, width: rectWidth - textWidth - offset, height: rectHeight };
                            break;
                        case "center":
                        case "top":
                        case "bottom":
                            textRect = { left: middle - textWidth / 2 - imgWidth / 2 - offset / 2, top: top, width: textWidth, height: rectHeight };
                            imageRect = { left: textRect.left + textWidth + offset, top: top, width: right - textRect.left - textWidth - offset, height: rectHeight };
                            break;
                        case "right":
                        case "topRight":
                        case "bottomRight":
                            textRect = { left: right - textWidth - imgWidth - offset, top: top, width: textWidth, height: rectHeight };
                            imageRect = { left: textRect.left + textWidth + offset, top: top, width: right - textRect.left - textWidth - offset, height: rectHeight };
                            break;

                    }
                    drawElement(img[0], imageRect, that.imgPosition, imgWidth, imgHeight);
                    drawElement(text[0], textRect, that.textPosition, textWidth, textHeight);

                    break;
                case "imageAboveText":

                    switch (that.imgPosition) {
                        case "topRight":
                        case "top":
                        case "topLeft":
                            imageRect = { left: left, top: top, width: rectWidth, height: imgHeight };
                            textRect = { left: left, top: top + imgHeight + offset, width: rectWidth, height: rectHeight - imgHeight - offset };
                            break;
                        case "left":
                        case "center":
                        case "right":
                            imageRect = { left: left, top: center - imgHeight / 2 - textHeight / 2 - offset / 2, width: rectWidth, height: imgHeight };
                            textRect = { left: left, top: imageRect.top + offset + imgHeight, width: rectWidth, height: rectHeight - imageRect.top - offset - imgHeight };
                            break;
                        case "bottomLeft":
                        case "bottom":
                        case "bottomRight":
                            imageRect = { left: left, top: bottom - imgHeight - textHeight - offset, width: rectWidth, height: imgHeight };
                            textRect = { left: left, top: imageRect.top + offset + imgHeight, width: rectWidth, height: textHeight };
                            break;

                    }
                    drawElement(img[0], imageRect, that.imgPosition, imgWidth, imgHeight);
                    drawElement(text[0], textRect, that.textPosition, textWidth, textHeight);
                    break;
                case "textAboveImage":
                    switch (that.textPosition) {
                        case "topRight":
                        case "top":
                        case "topLeft":
                            textRect = { left: left, top: top, width: rectWidth, height: textHeight };
                            imageRect = { left: left, top: top + textHeight + offset, width: rectWidth, height: rectHeight - textHeight - offset };
                            break;
                        case "left":
                        case "center":
                        case "right":
                            textRect = { left: left, top: center - imgHeight / 2 - textHeight / 2 - offset / 2, width: rectWidth, height: textHeight };
                            imageRect = { left: left, top: textRect.top + offset + textHeight, width: rectWidth, height: rectHeight - textRect.top - offset - textHeight };
                            break;
                        case "bottomLeft":
                        case "bottom":
                        case "bottomRight":
                            textRect = { left: left, top: bottom - imgHeight - textHeight - offset, width: rectWidth, height: textHeight };
                            imageRect = { left: left, top: textRect.top + offset + textHeight, width: rectWidth, height: imgHeight };
                            break;

                    }
                    drawElement(img[0], imageRect, that.imgPosition, imgWidth, imgHeight);
                    drawElement(text[0], textRect, that.textPosition, textWidth, textHeight);
        //var el = $("<div></div>");
        //            el.css('position', 'absolute');
        //            text.css('background', 'red');
        //            el.css('background', 'blue');
        //            el.css({ left: imageRect.left, top: imageRect.top, width: imageRect.width, height: imageRect.height });
        //            el.prependTo(that.host);
            
                    break;
                case "overlay":
                default:
                    textRect = { left: left, top: top, width: rectWidth, height: rectHeight };
                    imageRect = { left: left, top: top, width: rectWidth, height: rectHeight };

                    drawElement(img[0], imageRect, that.imgPosition, imgWidth, imgHeight);
                    drawElement(text[0], textRect, that.textPosition, textWidth, textHeight);

                    break;
            }
        },

        createInstance: function (args) {
            var self = this;
            self._setSize();

            if (self.imgSrc != "" || self.textPosition != "" || (self.element.value && self.element.value.indexOf("<") >= 0) || self.value != null)
            {
                self.refresh();
                self._addImage("jqxButton");
            }

            if (!self._ariaDisabled) {
                self.host.attr('role', 'button');
            }
            if (!self.overrideTheme) {
                self.host.addClass(self.toThemeProperty($.jqx.cssroundedcorners(self.roundedCorners)));
                if (self.enableDefault) {
                    self.host.addClass(self.toThemeProperty('jqx-button'));
                }
                self.host.addClass(self.toThemeProperty('jqx-widget'));
            }

            self.isTouchDevice = $.jqx.mobile.isTouchDevice();
            if (!self._ariaDisabled) {
                $.jqx.aria(this);
            }

            if (self.cursor != 'arrow') {
                if (!self.disabled) {
                    self.host.css({ cursor: self.cursor });
                }
                else {
                    self.host.css({ cursor: 'arrow' });
                }
            }

            var eventNames = 'mouseenter mouseleave mousedown focus blur';
            if (self._scrollAreaButton) {
                var eventNames = 'mousedown';
            }

            if (self.isTouchDevice) {
                self.addHandler(self.host, $.jqx.mobile.getTouchEventName('touchstart'), function (event) {
                    self.isPressed = true;
                    self.refresh();
                });
                self.addHandler($(document), $.jqx.mobile.getTouchEventName('touchend') + "." + self.element.id, function (event) {
                    self.isPressed = false;
                    self.refresh();
                });
            }

            self.addHandler(self.host, eventNames, function (event) {
                switch (event.type) {
                    case 'mouseenter':
                        if (!self.isTouchDevice) {
                            if (!self.disabled && self.enableHover) {
                                self.isMouseOver = true;
                                self.refresh();
                            }
                        }
                        break;
                    case 'mouseleave':
                        if (!self.isTouchDevice) {
                            if (!self.disabled && self.enableHover) {
                                self.isMouseOver = false;
                                self.refresh();
                            }
                        }
                        break;
                    case 'mousedown':
                        if (!self.disabled) {
                            self.isPressed = true;
                            self.refresh();
                        }
                        break;
                    case 'focus':
                        if (!self.disabled) {
                            self.isFocused = true;
                            self.refresh();
                        }
                        break;
                    case 'blur':
                        if (!self.disabled) {
                            self.isFocused = false;
                            self.refresh();
                        }
                        break;
                }
            });

            self.mouseupfunc = function (event) {
                if (!self.disabled) {
                    if (self.isPressed || self.isMouseOver) {
                        self.isPressed = false;
                        self.refresh();
                    }
                }
            }

            self.addHandler($(document), 'mouseup.button' + self.element.id, self.mouseupfunc);

            try {
                if (document.referrer != "" || window.frameElement) {
                    if (window.top != null && window.top != window.self) {
                        var parentLocation = '';
                        if (window.parent && document.referrer) {
                            parentLocation = document.referrer;
                        }

                        if (parentLocation.indexOf(document.location.host) != -1) {
                            var eventHandle = function (event) {
                                self.isPressed = false;
                                self.refresh();
                            };

                            if (window.top.document) {
                                self.addHandler($(window.top.document), 'mouseup', eventHandle);
                            }
                        }
                    }
                }
            }
            catch (error) {
            }
            
            self.propertyChangeMap['roundedCorners'] = function (instance, key, oldVal, value) {
                instance.host.removeClass(instance.toThemeProperty($.jqx.cssroundedcorners(oldVal)));
                instance.host.addClass(instance.toThemeProperty($.jqx.cssroundedcorners(value)));
            };
            self.propertyChangeMap['disabled'] = function (instance, key, oldVal, value) {
                if (oldVal != value) {
                    instance.refresh();
                    instance.host[0].disabled = value;
                    instance.host.attr('disabled', value);
                    if (!value) {
                        instance.host.css({ cursor: instance.cursor });
                    }
                    else {
                        instance.host.css({ cursor: 'default' });
                    }

                    $.jqx.aria(instance, "aria-disabled", instance.disabled);
                }
            };
            self.propertyChangeMap['rtl'] = function (instance, key, oldVal, value) {
                if (oldVal != value) {
                    instance.refresh();
                }
            };
            self.propertyChangeMap['template'] = function (instance, key, oldVal, value) {
                if (oldVal != value) {
                    instance.host.removeClass(instance.toThemeProperty("jqx-" + oldVal));
                    instance.refresh();
                }
            };
            self.propertyChangeMap['theme'] = function (instance, key, oldVal, value) {
                instance.host.removeClass();

                if (instance.enableDefault) {
                    instance.host.addClass(instance.toThemeProperty('jqx-button'));
                }
                instance.host.addClass(instance.toThemeProperty('jqx-widget'));
                if (!instance.overrideTheme) {
                    instance.host.addClass(instance.toThemeProperty($.jqx.cssroundedcorners(instance.roundedCorners)));
                }
                instance._oldCSSCurrent = null;
                instance.refresh();
            };
            if (self.disabled) {
                self.element.disabled = true;
                self.host.attr('disabled', true);
            }
        }, // createInstance

        resize: function (width, height) {
            this.width = width;
            this.height = height;
            this._setSize();
        },

        val: function () {
            var self = this;
            var input = self.host.find('input');
            if (input.length > 0) {
                if (arguments.length == 0 || typeof (value) == "object") {
                    return input.val();
                }
                input.val(value);
                self.refresh();
                return input.val();
            }

            if (arguments.length == 0 || typeof (value) == "object") {
                if (self.element.nodeName.toLowerCase() == "button") {
                    return $(self.element).text();
                }
                return self.element.value;
            }
            self.element.value = arguments[0];
            if (self.element.nodeName.toLowerCase() == "button") {
                $(self.element).text(arguments[0]);
            }

            self.refresh();
        },

        _setSize: function () {
            var self = this;
            if (self.width != null && (self.width.toString().indexOf("px") != -1 || self.width.toString().indexOf("%") != -1)) {
                self.host.css('width', self.width);
            }
            else {
                if (self.width != undefined && !isNaN(self.width)) {
                    self.host.css('width', self.width);
                }
            }
            if (self.height != null && (self.height.toString().indexOf("px") != -1 || self.height.toString().indexOf("%") != -1)) {
                self.host.css('height', self.height);
            }
            else if (self.height != undefined && !isNaN(self.height)) {
                self.host.css('height', parseInt(self.height));
            }
        },

        _removeHandlers: function () {
            var self = this;
            self.removeHandler(self.host, 'selectstart');
            self.removeHandler(self.host, 'click');
            self.removeHandler(self.host, 'focus');
            self.removeHandler(self.host, 'blur');
            self.removeHandler(self.host, 'mouseenter');
            self.removeHandler(self.host, 'mouseleave');
            self.removeHandler(self.host, 'mousedown');
            self.removeHandler($(document), 'mouseup.button' + self.element.id, self.mouseupfunc);
            if (self.isTouchDevice) {
                self.removeHandler(self.host, $.jqx.mobile.getTouchEventName('touchstart'));
                self.removeHandler($(document), $.jqx.mobile.getTouchEventName('touchend') + "." + self.element.id);
            }
            self.mouseupfunc = null;
            delete self.mouseupfunc;
        },

        focus: function()
        {
            this.host.focus();
        },

        destroy: function () {
            var self = this;
            self._removeHandlers();
            var vars = $.data(self.element, "jqxButton");
            if (vars) {
                delete vars.instance;
            }
            self.host.removeClass();
            self.host.removeData();
            self.host.remove();
            delete self.set;
            delete self.get;
            delete self.call;
            delete self.element;
            delete self.host;
        },

        render: function()
        {
            this.refresh();
        },

        propertiesChangedHandler: function (object, oldValues, newValues)
        {
            if (newValues && newValues.width && newValues.height && Object.keys(newValues).length == 2)
            {
                object._setSize();
                object.refresh();
            }
        },

        propertyChangedHandler: function (object, key, oldvalue, value) {
            if (this.isInitialized == undefined || this.isInitialized == false)
                return;

            if (value == oldvalue)
            {
                return;
            }

            if (object.batchUpdate && object.batchUpdate.width && object.batchUpdate.height && Object.keys(object.batchUpdate).length == 2)
            {
                return;
            }

            if (key == "textImageRelation" || key == "textPosition" || key == "imgPosition") {
                if (object._img) {
                    object._positionTextAndImage();
                }
                else object._addImage("jqxButton");
            }
            if (key == "imgSrc" || key == "imgWidth" || key == "imgHeight" || key == "value") {
                object._addImage("jqxButton");
            }

            if (key == "width" || key == "height")
            {
                object._setSize();
                object.refresh();
            }
        },

        refresh: function () {
            var self = this;
            if (self.overrideTheme)
                return;

            var cssFocused = self.toThemeProperty('jqx-fill-state-focus');
            var cssDisabled = self.toThemeProperty('jqx-fill-state-disabled');
            var cssNormal = self.toThemeProperty('jqx-fill-state-normal');

            if (!self.enableDefault) {
                cssNormal = "";
            }

            var cssHover = self.toThemeProperty('jqx-fill-state-hover');
            var cssPressed = self.toThemeProperty('jqx-fill-state-pressed');
            var cssPressedHover = self.toThemeProperty('jqx-fill-state-pressed');
            if (!self.enablePressed) {
                cssPressed = "";
            }
            var cssCurrent = '';

            if (!self.host) {
                return;
            }

            self.host[0].disabled = self.disabled;

            if (self.disabled) {
                if (self._oldCSSCurrent)
                {
                    self.host.removeClass(self._oldCSSCurrent);
                }
                cssCurrent = cssNormal + " " + cssDisabled;
                if (self.template !== "default" && self.template !== "") {
                    cssCurrent += " " + "jqx-" + self.template;
                    if (self.theme != "")
                    {
                        cssCurrent += " " + "jqx-" + self.template + "-" + self.theme;
                    }
                }
                self.host.addClass(cssCurrent);
                self._oldCSSCurrent = cssCurrent;
                return;
            }
            else {
                if (self.isMouseOver && !self.isTouchDevice) {
                    if (self.isPressed)
                        cssCurrent = cssPressedHover;
                    else
                        cssCurrent = cssHover;
                }
                else {
                    if (self.isPressed)
                        cssCurrent = cssPressed;
                    else
                        cssCurrent = cssNormal;
                }
            }

            if (self.isFocused) {
                cssCurrent += " " + cssFocused;
            }

            if (self.template !== "default" && self.template !== "") {
                cssCurrent += " " + "jqx-" + self.template;
                if (self.theme != "")
                {
                    cssCurrent += " " + "jqx-" + self.template + "-" + self.theme;
                }
            }

            if (cssCurrent != self._oldCSSCurrent) {
                if (self._oldCSSCurrent) {
                    self.host.removeClass(self._oldCSSCurrent);
                }
                self.host.addClass(cssCurrent);
                self._oldCSSCurrent = cssCurrent;
            }
            if (self.rtl) {
                self.host.addClass(self.toThemeProperty('jqx-rtl'));
                self.host.css('direction', 'rtl');
            }
        }
    });

    //// LinkButton
    $.jqx.jqxWidget("jqxLinkButton", "", {});

    $.extend($.jqx._jqxLinkButton.prototype, {
        defineInstance: function () {
            // enables / disables the button
            this.disabled = false;
            // sets height to the button.
            this.height = null;
            // sets width to the button.
            this.width = null;
            this.rtl = false;
            this.href = null;
        },

        createInstance: function (args) {
            var self = this;
            this.host.onselectstart = function () { return false; };
            this.host.attr('role', 'button');

            var height = this.height || this.host.height();
            var width = this.width || this.host.width();
            this.href = this.host.attr('href');
            this.target = this.host.attr('target');
            this.content = this.host.text();
            this.element.innerHTML = "";
            this.host.append("<input type='button' class='jqx-wrapper'/>");
            var wrapElement = this.host.find('input');
            wrapElement.addClass(this.toThemeProperty('jqx-reset'));
            wrapElement.width(width);
            wrapElement.height(height);
            wrapElement.val(this.content);
            this.host.find('tr').addClass(this.toThemeProperty('jqx-reset'));
            this.host.find('td').addClass(this.toThemeProperty('jqx-reset'));
            this.host.find('tbody').addClass(this.toThemeProperty('jqx-reset'));
            this.host.css('color', 'inherit');
            this.host.addClass(this.toThemeProperty('jqx-link'));

            wrapElement.css({ width: width });
            wrapElement.css({ height: height });
            var param = args == undefined ? {} : args[0] || {};
            wrapElement.jqxButton(param);

            if (this.disabled) {
                this.host[0].disabled = true;
            }

            this.propertyChangeMap['disabled'] = function (instance, key, oldVal, value) {
                instance.host[0].disabled = value;
                instance.host.find('input').jqxButton({ disabled: value });
            }

            this.addHandler(wrapElement, 'click', function (event) {
                if (!this.disabled) {
                    self.onclick(event);
                }
                return false;
            });
        },

        onclick: function (event) {
            if (this.target != null) {
                window.open(this.href, this.target);
            }
            else {
                window.location = this.href;
            }
        }
    });
    //// End of LinkButton

    //// RepeatButton
    $.jqx.jqxWidget("jqxRepeatButton", "jqxButton", {});

    $.extend($.jqx._jqxRepeatButton.prototype, {
        defineInstance: function () {
            this.delay = 50;
        },

        createInstance: function (args) {
            var self = this;

            var isTouchDevice = $.jqx.mobile.isTouchDevice();

            var up = !isTouchDevice ? 'mouseup.' + this.base.element.id : 'touchend.' + this.base.element.id;
            var down = !isTouchDevice ? 'mousedown.' + this.base.element.id : 'touchstart.' + this.base.element.id;

            this.addHandler($(document), up, function (event) {
                if (self.timeout != null) {
                    clearTimeout(self.timeout);
                    self.timeout = null;
                    self.refresh();
                }
                if (self.timer != undefined) {
                    clearInterval(self.timer);
                    self.timer = null;
                    self.refresh();
                }
            });

            this.addHandler(this.base.host, down, function (event) {
                if (self.timer != null) {
                    clearInterval(self.timer);
                }
 
                self.timeout = setTimeout(function () {
                    clearInterval(self.timer);
                    self.timer = setInterval(function (event) { self.ontimer(event); }, self.delay);
                }, 150);
            });

            this.mousemovefunc = function (event) {
                if (!isTouchDevice) {
                    if (event.which == 0) {
                        if (self.timer != null) {
                            clearInterval(self.timer);
                            self.timer = null;
                        }
                    }
                }
            }

            this.addHandler(this.base.host, 'mousemove', this.mousemovefunc);
        },

        destroy: function()
        {
            var isTouchDevice = $.jqx.mobile.isTouchDevice();
            var up = !isTouchDevice ? 'mouseup.' + this.base.element.id : 'touchend.' + this.base.element.id;
            var down = !isTouchDevice ? 'mousedown.' + this.base.element.id : 'touchstart.' + this.base.element.id;
            this.removeHandler(this.base.host, 'mousemove', this.mousemovefunc);
            this.removeHandler(this.base.host, down);
            this.removeHandler($(document), up);
            this.timer = null;
            delete this.mousemovefunc;
            delete this.timer;
            var vars = $.data(this.base.element, "jqxRepeatButton");
            if (vars) {
                delete vars.instance;
            }
            $(this.base.element).removeData();
            this.base.destroy();
            delete this.base;

        },

        stop: function () {
            clearInterval(this.timer);
            this.timer = null;
        },

        ontimer: function (event) {
            var event = new $.Event('click');
            if (this.base != null && this.base.host != null) {
                this.base.host.trigger(event);
            }
        }
    });
    //// End of RepeatButton
    //// ToggleButton
    $.jqx.jqxWidget("jqxToggleButton", "jqxButton", {});

    $.extend($.jqx._jqxToggleButton.prototype, {
        defineInstance: function () {
            this.toggled = false;
            this.uiToggle = true;
            this.aria =
            {
                "aria-checked": { name: "toggled", type: "boolean" },
                "aria-disabled": { name: "disabled", type: "boolean" }
            };
        },

        createInstance: function (args) {
            var self = this;
            self.base.overrideTheme = true;
            self.isTouchDevice = $.jqx.mobile.isTouchDevice();
            $.jqx.aria(this);

            self.propertyChangeMap['roundedCorners'] = function (instance, key, oldVal, value) {
                instance.base.host.removeClass(instance.toThemeProperty($.jqx.cssroundedcorners(oldVal)));
                instance.base.host.addClass(instance.toThemeProperty($.jqx.cssroundedcorners(value)));
            };

            self.propertyChangeMap['toggled'] = function (instance, key, oldVal, value) {
                instance.refresh();
            };
            self.propertyChangeMap['disabled'] = function (instance, key, oldVal, value) {
                instance.base.disabled = value;
                instance.refresh();
            };

            self.addHandler(self.base.host, 'click', function (event) {
                if (!self.base.disabled && self.uiToggle) {
                    self.toggle();
                }
            });

            if (!self.isTouchDevice) {
                self.addHandler(self.base.host, 'mouseenter', function (event) {
                    if (!self.base.disabled) {
                        self.refresh();
                    }
                });

                self.addHandler(self.base.host, 'mouseleave', function (event) {
                    if (!self.base.disabled) {
                        self.refresh();
                    }
                });
            }

            self.addHandler(self.base.host, 'mousedown', function (event) {
                if (!self.base.disabled) {
                    self.refresh();
                }
            });

            self.addHandler($(document), 'mouseup.togglebutton' + self.base.element.id, function (event) {
                if (!self.base.disabled) {
                    self.refresh();
                }
            });
        },

        destroy: function()
        {
            this._removeHandlers();
            this.base.destroy();
        },

        _removeHandlers: function () {
            this.removeHandler(this.base.host, 'click');
            this.removeHandler(this.base.host, 'mouseenter');
            this.removeHandler(this.base.host, 'mouseleave');
            this.removeHandler(this.base.host, 'mousedown');
            this.removeHandler($(document), 'mouseup.togglebutton' + this.base.element.id);
        },

        toggle: function () {
            this.toggled = !this.toggled;
            this.refresh();
            $.jqx.aria(this, "aria-checked", this.toggled);
        },

        unCheck: function () {
            this.toggled = false;
            this.refresh();
        },

        check: function () {
            this.toggled = true;
            this.refresh();
        },

        refresh: function () {
            var self = this;
            var cssDisabled = self.base.toThemeProperty('jqx-fill-state-disabled');
            var cssNormal = self.base.toThemeProperty('jqx-fill-state-normal');
            if (!self.base.enableDefault) {
                cssNormal = "";
            }
            var cssHover = self.base.toThemeProperty('jqx-fill-state-hover');
            var cssPressed = self.base.toThemeProperty('jqx-fill-state-pressed');
            var cssPressedHover = self.base.toThemeProperty('jqx-fill-state-pressed');
            var cssCurrent = '';
            self.base.host[0].disabled = self.base.disabled;

            if (self.base.disabled) {
                cssCurrent = cssNormal + " " + cssDisabled;
                self.base.host.addClass(cssCurrent);
                return;
            }
            else {
                if (self.base.isMouseOver && !self.isTouchDevice) {
                    if (self.base.isPressed || self.toggled)
                        cssCurrent = cssPressedHover;
                    else
                        cssCurrent = cssHover;
                }
                else {
                    if (self.base.isPressed || self.toggled)
                        cssCurrent = cssPressed;
                    else
                        cssCurrent = cssNormal;
                }
            }

            if (self.base.template !== "default" && self.base.template !== "") {
                cssCurrent += " " + "jqx-" + self.base.template;
                if (self.base.theme != "")
                {
                    cssCurrent += " " + "jqx-" + self.template + "-" + self.base.theme;
                }
            }

            if (self.base.host.hasClass(cssDisabled) && cssDisabled != cssCurrent)
                self.base.host.removeClass(cssDisabled);

            if (self.base.host.hasClass(cssNormal) && cssNormal != cssCurrent)
                self.base.host.removeClass(cssNormal);

            if (self.base.host.hasClass(cssHover) && cssHover != cssCurrent)
                self.base.host.removeClass(cssHover);

            if (self.base.host.hasClass(cssPressed) && cssPressed != cssCurrent)
                self.base.host.removeClass(cssPressed);

            if (self.base.host.hasClass(cssPressedHover) && cssPressedHover != cssCurrent)
                self.base.host.removeClass(cssPressedHover);

            if (!self.base.host.hasClass(cssCurrent))
                self.base.host.addClass(cssCurrent);
        }
    });
    //// End of ToggleButton

})(jqxBaseFramework);
