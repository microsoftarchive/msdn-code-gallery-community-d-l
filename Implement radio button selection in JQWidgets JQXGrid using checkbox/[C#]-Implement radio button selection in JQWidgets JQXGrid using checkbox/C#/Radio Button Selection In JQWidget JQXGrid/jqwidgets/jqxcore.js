/*
jQWidgets v4.1.2 (2016-Apr)
Copyright (c) 2011-2016 jQWidgets.
License: http://jqwidgets.com/license/
*/



var jqxBaseFramework = window.minQuery || window.jQuery;

(function ($) {
    $.jqx = $.jqx || {}

    $.jqx.define = function (namespace, classname, baseclass) {
        namespace[classname] = function () {
            if (this.baseType) {
                this.base = new namespace[this.baseType]();
                this.base.defineInstance();
            }
            this.defineInstance();
        }

        namespace[classname].prototype.defineInstance = function () { };
        namespace[classname].prototype.base = null;
        namespace[classname].prototype.baseType = undefined;

        if (baseclass && namespace[baseclass])
            namespace[classname].prototype.baseType = baseclass;
    }

    // method call
    $.jqx.invoke = function (object, args) {
        if (args.length == 0)
            return;

        var method = typeof (args) == Array || args.length > 0 ? args[0] : args;
        var methodArg = typeof (args) == Array || args.length > 1 ? Array.prototype.slice.call(args, 1) : $({}).toArray();

        while (object[method] == undefined && object.base != null) {
            if (object[method] != undefined && $.isFunction(object[method]))
                return object[method].apply(object, methodArg);

            if (typeof method == 'string') {
                var methodLowerCase = method.toLowerCase();
                if (object[methodLowerCase] != undefined && $.isFunction(object[methodLowerCase])) {
                    return object[methodLowerCase].apply(object, methodArg);
                }
            }
            object = object.base;
        }

        if (object[method] != undefined && $.isFunction(object[method]))
            return object[method].apply(object, methodArg);

        if (typeof method == 'string') {
            var methodLowerCase = method.toLowerCase();
            if (object[methodLowerCase] != undefined && $.isFunction(object[methodLowerCase])) {
                return object[methodLowerCase].apply(object, methodArg);
            }
        }

        return;
    }
    $.jqx.hasProperty = function (obj, property) {
        if (typeof (property) == 'object') {
            for (var prop in property) {
                var o = obj;
                while (o) {
                    if (o.hasOwnProperty(prop))
                        return true;
                    if (o.hasOwnProperty(prop.toLowerCase()))
                        return true;
                    o = o.base;
                }
                return false;
            }
        }
        else {
            while (obj) {
                if (obj.hasOwnProperty(property))
                    return true;
                if (obj.hasOwnProperty(property.toLowerCase()))
                    return true;
                obj = obj.base;
            }
        }

        return false;
    }

    $.jqx.hasFunction = function (object, args) {
        if (args.length == 0)
            return false;

        if (object == undefined)
            return false;

        var method = typeof (args) == Array || args.length > 0 ? args[0] : args;
        var methodArg = typeof (args) == Array || args.length > 1 ? Array.prototype.slice.call(args, 1) : {};

        while (object[method] == undefined && object.base != null) {
            if (object[method] && $.isFunction(object[method]))
                return true;

            if (typeof method == 'string') {
                var methodLowerCase = method.toLowerCase();
                if (object[methodLowerCase] && $.isFunction(object[methodLowerCase]))
                    return true;
            }
            object = object.base;
        }

        if (object[method] && $.isFunction(object[method]))
            return true;

        if (typeof method == 'string') {
            var methodLowerCase = method.toLowerCase();
            if (object[methodLowerCase] && $.isFunction(object[methodLowerCase]))
                return true;
        }

        return false;
    }

    $.jqx.isPropertySetter = function (obj, args) {
        if (args.length == 1 && typeof (args[0]) == 'object')
            return true;

        if (args.length == 2 &&
            typeof (args[0]) == 'string' &&
            !$.jqx.hasFunction(obj, args)) {
            return true;
        }

        return false;
    }

    $.jqx.validatePropertySetter = function (obj, args, suppressException) {
        if (!$.jqx.propertySetterValidation)
            return true;

        if (args.length == 1 && typeof (args[0]) == 'object') {
            for (var i in args[0]) {
                var o = obj;
                while (!o.hasOwnProperty(i) && o.base)
                    o = o.base;

                if (!o || !o.hasOwnProperty(i)) {
                    if (!suppressException) {
                        var hasLowerCase = o.hasOwnProperty(i.toString().toLowerCase());
                        if (!hasLowerCase) {
                            throw 'Invalid property: ' + i;
                        }
                        else return true;
                    }
                    return false;
                }
            }

            return true;
        }

        if (args.length != 2) {
            if (!suppressException)
                throw 'Invalid property: ' + args.length >= 0 ? args[0] : '';

            return false;
        }

        while (!obj.hasOwnProperty(args[0]) && obj.base)
            obj = obj.base;

        if (!obj || !obj.hasOwnProperty(args[0])) {
            if (!suppressException)
                throw 'Invalid property: ' + args[0];

            return false;
        }

        return true;
    }

    if (!Object.keys)
    {
        Object.keys = (function ()
        {
            'use strict';
            var hasOwnProperty = Object.prototype.hasOwnProperty,
                hasDontEnumBug = !({ toString: null }).propertyIsEnumerable('toString'),
                dontEnums = [
                  'toString',
                  'toLocaleString',
                  'valueOf',
                  'hasOwnProperty',
                  'isPrototypeOf',
                  'propertyIsEnumerable',
                  'constructor'
                ],
                dontEnumsLength = dontEnums.length;

            return function (obj)
            {
                if (typeof obj !== 'object' && (typeof obj !== 'function' || obj === null))
                {
                    throw new TypeError('Object.keys called on non-object');
                }

                var result = [], prop, i;

                for (prop in obj)
                {
                    if (hasOwnProperty.call(obj, prop))
                    {
                        result.push(prop);
                    }
                }

                if (hasDontEnumBug)
                {
                    for (i = 0; i < dontEnumsLength; i++)
                    {
                        if (hasOwnProperty.call(obj, dontEnums[i]))
                        {
                            result.push(dontEnums[i]);
                        }
                    }
                }
                return result;
            };
        }());
    }

    $.jqx.set = function (object, args) {
        var newValuesLength = 0;
        if (args.length == 1 && typeof (args[0]) == 'object') {
            if (object.isInitialized && Object.keys && Object.keys(args[0]).length > 1) {
                var element = !object.base ? object.element : object.base.element;
                var initArgs = $.data(element, object.widgetName).initArgs;
                if (initArgs && JSON && JSON.stringify && args[0] && initArgs[0])
                {
                    try
                    {
                        if (JSON.stringify(args[0]) == JSON.stringify(initArgs[0]))
                        {
                            var toReturn = true;
                            $.each(args[0], function (key, value)
                            {
                                if (object[key] != value)
                                {
                                    toReturn = false;
                                    return false;
                                }
                            });
                            if (toReturn)
                            {
                                return;
                            }
                        }
                    }
                    catch(err)
                    {
                    }
                }
                object.batchUpdate = args[0];
                var oldValues = {};
                var newValues = {};
                $.each(args[0], function (key, value) {
                    var obj = object;
                    while (!obj.hasOwnProperty(key) && obj.base != null)
                        obj = obj.base;

                    if (obj.hasOwnProperty(key)) {
                        if (object[key] != value) {
                            oldValues[key] = object[key];
                            newValues[key] = value;
                            newValuesLength++;
                        }
                    }
                    else if (obj.hasOwnProperty(key.toLowerCase())) {
                        if (object[key.toLowerCase()] != value) {
                            oldValues[key.toLowerCase()] = object[key.toLowerCase()];
                            newValues[key.toLowerCase()] = value;
                            newValuesLength++;
                        }
                    }
                });
                if (newValuesLength < 2) {
                    object.batchUpdate = null;
                }
            }

            $.each(args[0], function (key, value) {
                var obj = object;
                while (!obj.hasOwnProperty(key) && obj.base != null)
                    obj = obj.base;

                if (obj.hasOwnProperty(key)) {
                    $.jqx.setvalueraiseevent(obj, key, value);
                }
                else if (obj.hasOwnProperty(key.toLowerCase())) {
                    $.jqx.setvalueraiseevent(obj, key.toLowerCase(), value);
                }
                else if ($.jqx.propertySetterValidation)
                    throw "jqxCore: invalid property '" + key + "'";
            });

            if (object.batchUpdate != null) {
                object.batchUpdate = null;
                if (object.propertiesChangedHandler && newValuesLength > 1) {
                    object.propertiesChangedHandler(object, oldValues, newValues);
                }
            }
        }
        else if (args.length == 2) {
            while (!object.hasOwnProperty(args[0]) && object.base)
                object = object.base;

            if (object.hasOwnProperty(args[0])) {
                $.jqx.setvalueraiseevent(object, args[0], args[1]);
            }
            else if (object.hasOwnProperty(args[0].toLowerCase())) {
                $.jqx.setvalueraiseevent(object, args[0].toLowerCase(), args[1]);
            }
            else if ($.jqx.propertySetterValidation)
                throw "jqxCore: invalid property '" + args[0] + "'";
        }
    }

    $.jqx.setvalueraiseevent = function (object, key, value) {
        var oldVal = object[key];

        object[key] = value;

        if (!object.isInitialized)
            return;

        if (object.propertyChangedHandler != undefined)
            object.propertyChangedHandler(object, key, oldVal, value);

        if (object.propertyChangeMap != undefined && object.propertyChangeMap[key] != undefined)
            object.propertyChangeMap[key](object, key, oldVal, value);
    };

    $.jqx.get = function (object, args) {
        if (args == undefined || args == null)
            return undefined;

        if (object.propertyMap) {
            var newVal = object.propertyMap(args);
            if (newVal != null)
                return newVal;
        }

        if (object.hasOwnProperty(args))
            return object[args];

        if (object.hasOwnProperty(args.toLowerCase()))
            return object[args.toLowerCase()];

        var arg = undefined;
        if (typeof (args) == Array) {
            if (args.length != 1)
                return undefined;
            arg = args[0];
        }
        else if (typeof (args) == 'string')
            arg = args;

        while (!object.hasOwnProperty(arg) && object.base)
            object = object.base;

        if (object)
            return object[arg];

        return undefined;
    }

    $.jqx.serialize = function (obj) {
        var txt = '';
        if ($.isArray(obj)) {
            txt = '['
            for (var i = 0; i < obj.length; i++) {
                if (i > 0)
                    txt += ', ';
                txt += $.jqx.serialize(obj[i]);
            }
            txt += ']';
        }
        else if (typeof (obj) == 'object') {
            txt = '{';
            var j = 0;
            for (var i in obj) {
                if (j++ > 0)
                    txt += ', ';
                txt += i + ': ' + $.jqx.serialize(obj[i]);
            }
            txt += '}';
        }
        else
            txt = obj.toString();

        return txt;
    }

    $.jqx.propertySetterValidation = true;

    $.jqx.jqxWidgetProxy = function (controlName, element, args) {
        var host = $(element);
        var vars = $.data(element, controlName);
        if (vars == undefined) {
            return undefined;
        }

        var obj = vars.instance;

        if ($.jqx.hasFunction(obj, args))
            return $.jqx.invoke(obj, args);

        if ($.jqx.isPropertySetter(obj, args)) {
            if ($.jqx.validatePropertySetter(obj, args)) {
                $.jqx.set(obj, args);
                return undefined;
            }
        } else {
            if (typeof (args) == 'object' && args.length == 0)
                return;
            else if (typeof (args) == 'object' && args.length == 1 && $.jqx.hasProperty(obj, args[0]))
                return $.jqx.get(obj, args[0]);
            else if (typeof (args) == 'string' && $.jqx.hasProperty(obj, args[0]))
                return $.jqx.get(obj, args);
        }

        throw "jqxCore: Invalid parameter '" + $.jqx.serialize(args) + "' does not exist.";
        return undefined;
    }

    $.jqx.applyWidget = function (element, controlName, args, instance) {
        var WinJS = false;
        try {
            WinJS = window.MSApp != undefined;
        }
        catch (e) {
        }

        var host = $(element);
        if (!instance) {
            instance = new $.jqx['_' + controlName]();
        }
        else {
            instance.host = host;
            instance.element = element;
        }
        if (element.id == "") {
            element.id = $.jqx.utilities.createId();
        }

        var vars = { host: host, element: element, instance: instance, initArgs: args };

        instance.widgetName = controlName;

        $.data(element, controlName, vars);
        $.data(element, 'jqxWidget', vars.instance);

        var inits = new Array();
        var instance = vars.instance;
        while (instance) {
            instance.isInitialized = false;
            inits.push(instance);
            instance = instance.base;
        }
        inits.reverse();
        inits[0].theme = $.jqx.theme || '';

        $.jqx.jqxWidgetProxy(controlName, element, args);

        for (var i in inits) {
            instance = inits[i];
            if (i == 0) {
                instance.host = host;
                instance.element = element;
                instance.WinJS = WinJS;
            }
            if (instance != undefined) {
                if (instance.definedInstance) {
                    instance.definedInstance();
                }
                if (instance.createInstance != null) {
                    if (WinJS) {
                        MSApp.execUnsafeLocalFunction(function () {
                            instance.createInstance(args);
                        });
                    }
                    else {
                        instance.createInstance(args);
                    }
                }
            }
        }

        for (var i in inits) {
            if (inits[i] != undefined) {
                inits[i].isInitialized = true;
            }
        }

        if (WinJS) {
            MSApp.execUnsafeLocalFunction(function () {
                vars.instance.refresh(true);
            });
        }
        else {
            vars.instance.refresh(true);
        }

    }

    $.jqx.jqxWidget = function (name, base, params) {
        var WinJS = false;
        try {
            jqxArgs = Array.prototype.slice.call(params, 0);
        }
        catch (e) {
            jqxArgs = '';
        }

        try {
            WinJS = window.MSApp != undefined;
        }
        catch (e) {
        }

        var controlName = name;

        var baseControl = '';
        if (base)
            baseControl = '_' + base;
        $.jqx.define($.jqx, '_' + controlName, baseControl);

        var widgets = new Array();
     
        if (!window[controlName]) {
            var serializeObject = function(data) {
                if (data == null) return "";
                var dataType = $.type(data);
                switch (dataType) {
                    case "string":
                    case "number":
                    case "date":
                    case "boolean":
                    case "bool":
                        if (data === null)
                            return "";
                        return data.toString()
                }

                var str = "";
                $.each(data, function (index) {
                    var val = this;
                    if (index > 0) str += ', ';
                    str += "[";
                    var m = 0;

                    if ($.type(val) == "object") {
                        for (var obj in val) {
                            if (m > 0) str += ', ';
                            str += '{' + obj + ":" + val[obj] + '}';
                            m++;
                        }
                    }
                    else {
                        if (m > 0) str += ', ';
                        str += '{' + index + ":" + val + '}';
                        m++;
                    }

                    str += "]";
                });
                return str;
            }

            window[controlName] = function (selector, params) {
                var args = [];
                if (!params) {
                    params = {};
                }
                args.push(params);

                var uid = selector;
                if ($.type(uid) === "object" && selector[0]) {
                    uid = selector[0].id;
                    if (uid === "") {
                        uid = selector[0].id = $.jqx.utilities.createId();
                    }
                }
            
                if (window.jqxWidgets && window.jqxWidgets[uid]) {
                    if (params) {
                        $.each(window.jqxWidgets[uid], function (index) {
                            var data = $(this.element).data();
                            if (data && data.jqxWidget) {
                                $(this.element)[controlName](params);
                            }
                        });
                    }
                    if (window.jqxWidgets[uid].length == 1) {
                        var data = $(window.jqxWidgets[uid][0].widgetInstance.element).data();
                        if (data && data.jqxWidget) {
                            return window.jqxWidgets[uid][0];
                        }
                    }

                    var data = $(window.jqxWidgets[uid][0].widgetInstance.element).data();
                    if (data && data.jqxWidget) {
                        return window.jqxWidgets[uid];
                    }
                }

                var elements = $(selector);
                if (elements.length === 0) {
                    throw new Error('Invalid Selector - ' + selector + '! Please, check whether the used ID or CSS Class name is correct.');
                }
                var instances = [];

           
                $.each(elements, function (index) {
                    var element = elements[index];
                    var elementClone = null;
                    if (!widgets[controlName]) {
                        var id = element.id;
                        element.id = "";
                        elementClone = $(element).clone();
                        element.id = id;
                    }
                    $.jqx.applyWidget(element, controlName, args, undefined);
                    if (!widgets[controlName]) {
                        var instance = $.data(element, 'jqxWidget');
                        var properties = elementClone[controlName]().data().jqxWidget.defineInstance();
                        var widgetConstructor = function (element) {
                            var instance = $.data(element, 'jqxWidget');
                            this.widgetInstance = instance;
                            var widget = $.extend(this, instance);
                            widget.on = function (eventName, callback) {
                               widget.addHandler(widget.host, eventName, callback);
                            }
                            widget.off = function (eventName) {
                               widget.removeHandler(widget.host, eventName);
                            }
 
                            return widget;
                        }
                        widgets[controlName] = widgetConstructor;
                        $.each(properties, function (property, currentValue) {
                            Object.defineProperty(widgetConstructor.prototype, property, {
                                get: function () {
                                    if (this.widgetInstance) {
                                        return this.widgetInstance[property];
                                    }
                                    return currentValue;
                                },
                                set: function (newValue) {
                                    if (this.widgetInstance && this.widgetInstance[property] != newValue) {
                                        if (this.widgetInstance[property] != newValue && serializeObject(this.widgetInstance[property]) != serializeObject(newValue)) {
                                            var settings = {};
                                            settings[property] = newValue;
                                            this.widgetInstance.host[controlName](settings);
                                            this.widgetInstance[property] = newValue;
                                        }
                                    }
                                }
                            });
                        });
                    }
                    var instance = new widgets[controlName](element);
                    instances.push(instance);
                    if (!window.jqxWidgets) {
                        window.jqxWidgets = new Array();
                    }
                    if (!window.jqxWidgets[uid]) {
                        window.jqxWidgets[uid] = new Array();
                    }
                    window.jqxWidgets[uid].push(instance);
                });

                if (instances.length === 1)
                    return instances[0];
                
                return instances;

            }
        }

        $.fn[controlName] = function () {
            var args = Array.prototype.slice.call(arguments, 0);

            if (args.length == 0 || (args.length == 1 && typeof (args[0]) == 'object')) {
                if (this.length == 0) {
                    if (this.selector) {
                        throw new Error('Invalid Selector - ' + this.selector + '! Please, check whether the used ID or CSS Class name is correct.');
                    }
                    else {
                        throw new Error('Invalid Selector! Please, check whether the used ID or CSS Class name is correct.');
                    }
                }

                return this.each(function () {
                    var host = $(this);
                    var element = this; // element == this == host[0]
                    var vars = $.data(element, controlName);

                    if (vars == null) {
                        $.jqx.applyWidget(element, controlName, args, undefined);
                    }
                    else {
                        $.jqx.jqxWidgetProxy(controlName, this, args);
                    }
                }); // each
            }
            else {
                if (this.length == 0) {
                    if (this.selector) {
                        throw new Error('Invalid Selector - ' + this.selector + '! Please, check whether the used ID or CSS Class name is correct.');
                    }
                    else {
                        throw new Error('Invalid Selector! Please, check whether the used ID or CSS Class name is correct.');
                    }
                }

                var returnVal = null;

                var cnt = 0;
                this.each(function () {
                    var result = $.jqx.jqxWidgetProxy(controlName, this, args);

                    if (cnt == 0) {
                        returnVal = result;
                        cnt++;
                    }
                    else {
                        if (cnt == 1) {
                            var tmp = [];
                            tmp.push(returnVal);
                            returnVal = tmp;
                        }
                        returnVal.push(result);
                    }
                }); // each
            }

            return returnVal;
        }

        try {
            $.extend($.jqx['_' + controlName].prototype, Array.prototype.slice.call(params, 0)[0]);
        }
        catch (e) {
        }

        $.extend($.jqx['_' + controlName].prototype, {
            toThemeProperty: function (propertyName, override) {
                return $.jqx.toThemeProperty(this, propertyName, override);
            }
        });

        $.jqx['_' + controlName].prototype.refresh = function () {
            if (this.base)
                this.base.refresh(true);
        }
        $.jqx['_' + controlName].prototype.createInstance = function () {
        }
        $.jqx['_' + controlName].prototype.applyTo = function (element, args) {
            if (!(args instanceof Array)) {
                var a = [];
                a.push(args);
                args = a;
            }

            $.jqx.applyWidget(element, controlName, args, this);
        }

        $.jqx['_' + controlName].prototype.getInstance = function () {
            return this;
        }
        $.jqx['_' + controlName].prototype.propertyChangeMap = {};

        $.jqx['_' + controlName].prototype.addHandler = function (source, events, func, data) {
            $.jqx.addHandler(source, events, func, data);
        };

        $.jqx['_' + controlName].prototype.removeHandler = function (source, events, func) {
            $.jqx.removeHandler(source, events, func);
        };
    } // jqxWidget

    $.jqx.toThemeProperty = function (instance, propertyName, override) {
        if (instance.theme == '')
            return propertyName;

        var split = propertyName.split(' ');
        var result = '';
        for (var i = 0; i < split.length; i++) {
            if (i > 0)
                result += ' ';

            var key = split[i];

            if (override != null && override)
                result += key + '-' + instance.theme;
            else
                result += key + ' ' + key + '-' + instance.theme;
        }

        return result;
    }


    $.jqx.addHandler = function (source, eventsList, func, data) {
        var events = eventsList.split(' ');

        for (var i = 0; i < events.length; i++) {
            var event = events[i];

            if (window.addEventListener) {
                switch (event) {
                    case 'mousewheel':
                        if ($.jqx.browser.mozilla) {
                            source[0].addEventListener('DOMMouseScroll', func, false);
                        }
                        else {
                            source[0].addEventListener('mousewheel', func, false);
                        }
                        continue;
                    case 'mousemove':
                        if (!data) {
                            source[0].addEventListener('mousemove', func, false);
                            continue;
                        }
                        break;
                }
            }

            if (data == undefined || data == null) {
                if (source.on)
                    source.on(event, func);
                else
                    source.bind(event, func);
            }
            else {
                if (source.on)
                    source.on(event, data, func);
                else
                    source.bind(event, data, func);
            }
        } // for
    };

    $.jqx.removeHandler = function (source, eventsList, func) {
        if (!eventsList) {
            if (source.off)
                source.off();
            else
                source.unbind();
            return;
        }
        var events = eventsList.split(' ');

        for (var i = 0; i < events.length; i++) {
            var event = events[i];

            if (window.removeEventListener) {
                switch (event) {
                    case 'mousewheel':
						if ($.jqx.browser.mozilla) {
                            source[0].removeEventListener('DOMMouseScroll', func, false);
                        }
                        else {
                            source[0].removeEventListener('mousewheel', func, false);
                        }
                        continue;
                    case 'mousemove':
                        if (func) {
                            source[0].removeEventListener('mousemove', func, false);
                            continue;
                        }
                        break;
                }
            }

            if (event == undefined) {
                if (source.off)
                    source.off();
                else
                    source.unbind();
                continue;
            }

            if (func == undefined) {
                if (source.off)
                    source.off(event);
                else
                    source.unbind(event);
            }
            else {
                if (source.off)
                    source.off(event, func);
                else
                    source.unbind(event, func);
            }
        }
    };

    $.jqx.theme = $.jqx.theme || "";
    $.jqx.scrollAnimation = $.jqx.scrollAnimation || false;
    $.jqx.resizeDelay = $.jqx.resizeDelay || 10;

    $.jqx.ready = function () {
        $(window).trigger('jqxReady');
    }
    $.jqx.init = function () {
        $.each(arguments[0], function (index, value) {
            if (index == "theme") {
                $.jqx.theme = value;
            }
            if (index == "scrollBarSize") {
                $.jqx.utilities.scrollBarSize = value;
            }
            if (index == "touchScrollBarSize") {
                $.jqx.utilities.touchScrollBarSize = value;
            }
            if (index == "scrollBarButtonsVisibility") {
                $.jqx.utilities.scrollBarButtonsVisibility = value;
            }
        });
    }

    // Utilities
    $.jqx.utilities = $.jqx.utilities || {};
    $.extend($.jqx.utilities,
    {
        scrollBarSize: 15,
        touchScrollBarSize: 0,
        scrollBarButtonsVisibility: "visible",
        createId: function () {
            var S4 = function () {
                return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
            };
            return "jqxWidget" + S4() + S4();
        },

        setTheme: function (oldTheme, theme, element) {
            if (typeof element === 'undefined') {
                return;
            }
            var classNames = element[0].className.split(' '),
                oldClasses = [], newClasses = [],
                children = element.children();
            for (var i = 0; i < classNames.length; i += 1) {
                if (classNames[i].indexOf(oldTheme) >= 0) {
                    if (oldTheme.length > 0) {
                        oldClasses.push(classNames[i]);
                        newClasses.push(classNames[i].replace(oldTheme, theme));
                    }
                    else {
                        newClasses.push(classNames[i].replace("-" + theme, "") + '-' + theme);
                    }
                }
            }
            this._removeOldClasses(oldClasses, element);
            this._addNewClasses(newClasses, element);
            for (var i = 0; i < children.length; i += 1) {
                this.setTheme(oldTheme, theme, $(children[i]));
            }
        },

        _removeOldClasses: function (classes, element) {
            for (var i = 0; i < classes.length; i += 1) {
                element.removeClass(classes[i]);
            }
        },

        _addNewClasses: function (classes, element) {
            for (var i = 0; i < classes.length; i += 1) {
                element.addClass(classes[i]);
            }
        },

        getOffset: function (el) {
            var left = $.jqx.mobile.getLeftPos(el[0]);
            var top = $.jqx.mobile.getTopPos(el[0]);
            return { top: top, left: left };
        },

        resize: function (element, callback, destroy, checkForHidden) {
            if (checkForHidden === undefined) {
                checkForHidden = true;
            }

            var index = -1;
            var that = this;
            var getHiddenIndex = function (element) {
                if (!that.hiddenWidgets) {
                    return -1;
                }

                var hiddenIndex = -1;
                for (var i = 0; i < that.hiddenWidgets.length; i++) {
                    if (element.id) {
                        if (that.hiddenWidgets[i].id == element.id) {
                            hiddenIndex = i;
                            break;
                        }
                    }
                    else {
                        if (that.hiddenWidgets[i].id == element[0].id) {
                            hiddenIndex = i;
                            break;
                        }
                    }
                }
                return hiddenIndex;
            }


            if (this.resizeHandlers) {
                for (var i = 0; i < this.resizeHandlers.length; i++) {
                    if (element.id) {
                        if (this.resizeHandlers[i].id == element.id) {
                            index = i;
                            break;
                        }
                    }
                    else {
                        if (this.resizeHandlers[i].id == element[0].id) {
                            index = i;
                            break;
                        }
                    }
                }

                if (destroy === true) {
                    if (index != -1) {
                        this.resizeHandlers.splice(index, 1);
                    }

                    if (this.resizeHandlers.length == 0) {
                        var w = $(window);
                        if (w.off) {
                            w.off('resize.jqx');
                            w.off('orientationchange.jqx');
                            w.off('orientationchanged.jqx');
                        }
                        else {
                            w.unbind('resize.jqx');
                            w.unbind('orientationchange.jqx');
                            w.unbind('orientationchanged.jqx');
                        }
                        this.resizeHandlers = null;
                    }
                    var hiddenIndex = getHiddenIndex(element);
                    if (hiddenIndex != -1 && this.hiddenWidgets) {
                        this.hiddenWidgets.splice(hiddenIndex, 1);
                    }
                    return;
                }
            }
            else if (destroy === true) {
                var hiddenIndex = getHiddenIndex(element);
                if (hiddenIndex != -1 && this.hiddenWidgets) {
                    this.hiddenWidgets.splice(hiddenIndex, 1);
                }
                return;
            }
            var that = this;
            var doResize = function (isHidden, type) {
                if (!that.resizeHandlers)
                    return;

                var getParentsCount = function (element) {
                    var index = -1;
                    var parent = element.parentNode;
                    while (parent) {
                        index++;
                        parent = parent.parentNode;
                    }
                    return index;
                }

                var compare = function (value1, value2) {
                    if (!value1.widget || !value2.widget)
                        return 0;

                    var parents1 = getParentsCount(value1.widget[0]);
                    var parents2 = getParentsCount(value2.widget[0]);

                    try {
                        if (parents1 < parents2) { return -1; }
                        if (parents1 > parents2) { return 1; }
                    }
                    catch (error) {
                        var er = error;
                    }

                    return 0;
                };
                var handleHiddenWidgets = function (delay) {
                    if (that.hiddenWidgets.length > 0) {
                        that.hiddenWidgets.sort(compare);
                        var updateHiddenWidgets = function () {
                            var hasHiddenWidget = false;
                            var currentHiddenWidgets = new Array();
                            for (var p = 0; p < that.hiddenWidgets.length; p++) {
                                var handler = that.hiddenWidgets[p];
                                if ($.jqx.isHidden(handler.widget)) {
                                    hasHiddenWidget = true;
                                    currentHiddenWidgets.push(handler);
                                }
                                else {
                                    if (handler.callback) {
                                        handler.callback(type);
                                    }
                                }
                            }
                            that.hiddenWidgets = currentHiddenWidgets;
                            if (!hasHiddenWidget) {
                                clearInterval(that.__resizeInterval);
                            }
                        }
                        if (delay == false) {
                            updateHiddenWidgets();
                            if (that.__resizeInterval) clearInterval(that.__resizeInterval);
                            return;
                        }
                        if (that.__resizeInterval) clearInterval(that.__resizeInterval);
                        that.__resizeInterval = setInterval(function () {
                            updateHiddenWidgets();
                        }, 100);
                    }
                }

                if (that.hiddenWidgets && that.hiddenWidgets.length > 0) {
                    handleHiddenWidgets(false);
                }
                that.hiddenWidgets = new Array();
                that.resizeHandlers.sort(compare);
                for (var i = 0; i < that.resizeHandlers.length; i++) {
                    var handler = that.resizeHandlers[i];
                    var widget = handler.widget;
                    var data = handler.data;
                    if (!data) continue;
                    if (!data.jqxWidget) continue;

                    var width = data.jqxWidget.width;
                    var height = data.jqxWidget.height;

                    if (data.jqxWidget.base) {
                        if (width == undefined) {
                            width = data.jqxWidget.base.width;
                        }
                        if (height == undefined) {
                            height = data.jqxWidget.base.height;
                        }
                    }

                    if (width === undefined && height === undefined) {
                        width = data.jqxWidget.element.style.width;
                        height = data.jqxWidget.element.style.height;
                    }

                    var percentageSize = false;
                    if (width != null && width.toString().indexOf("%") != -1) {
                        percentageSize = true;
                    }

                    if (height != null && height.toString().indexOf("%") != -1) {
                        percentageSize = true;
                    }

                    if ($.jqx.isHidden(widget)) {
                        if (getHiddenIndex(widget) === -1) {
                            if (percentageSize || isHidden === true) {
                                if (handler.data.nestedWidget !== true) {
                                    that.hiddenWidgets.push(handler);
                                }
                            }
                        }
                    }
                    else if (isHidden === undefined || isHidden !== true) {
                        if (percentageSize) {
                            handler.callback(type);
                            if (that.hiddenWidgets.indexOf(handler) >= 0) {
                                that.hiddenWidgets.splice(that.hiddenWidgets.indexOf(handler), 1);
                            }
                        }
                        if (data.jqxWidget.element) {
                            var widgetClass = data.jqxWidget.element.className;
                            if (widgetClass.indexOf('dropdownlist') >= 0 || widgetClass.indexOf('datetimeinput') >= 0 || widgetClass.indexOf('combobox') >= 0 || widgetClass.indexOf('menu') >= 0) {
                                if (data.jqxWidget.isOpened) {
                                    var opened = data.jqxWidget.isOpened();
                                    if (opened) {
                                        if (type && type == "resize" && $.jqx.mobile.isTouchDevice())
                                            continue;

                                        data.jqxWidget.close();
                                    }
                                }
                            }
                        }
                    }
                };
             
                handleHiddenWidgets();
            }

            if (!this.resizeHandlers) {
                this.resizeHandlers = new Array();

                var w = $(window);
                if (w.on) {
                    this._resizeTimer = null;
                    this._initResize = null;
                    w.on('resize.jqx', function (event) {
                        if (that._resizeTimer != undefined) {
                            clearTimeout(that._resizeTimer);
                        }
                        if (!that._initResize) {
                            that._initResize = true;
                            doResize(null, 'resize');
                        }
                        else {
                            that._resizeTimer = setTimeout(function () {
                                doResize(null, 'resize');
                            }, $.jqx.resizeDelay);
                        }
                    });
                    w.on('orientationchange.jqx', function (event) {
                        doResize(null, 'orientationchange');
                    });
                    w.on('orientationchanged.jqx', function (event) {
                        doResize(null, 'orientationchange');
                    });
                }
                else {
                    w.bind('resize.jqx', function (event) {
                        doResize(null, 'orientationchange');
                    });
                    w.bind('orientationchange.jqx', function (event) {
                        doResize(null, 'orientationchange');
                    });
                    w.bind('orientationchanged.jqx', function (event) {
                        doResize(null, 'orientationchange');
                    });
                }
            }
            var elementData = element.data();
            if (checkForHidden) {
                if (index === -1) {
                    this.resizeHandlers.push({ id: element[0].id, widget: element, callback: callback, data: elementData });
                }
            }
            try
            {
                var width = elementData.jqxWidget.width;
                var height = elementData.jqxWidget.height;

                if (elementData.jqxWidget.base)
                {
                    if (width == undefined)
                    {
                        width = elementData.jqxWidget.base.width;
                    }
                    if (height == undefined)
                    {
                        height = elementData.jqxWidget.base.height;
                    }
                }

                if (width === undefined && height === undefined)
                {
                    width = elementData.jqxWidget.element.style.width;
                    height = elementData.jqxWidget.element.style.height;
                }

                var percentageSize = false;
                if (width != null && width.toString().indexOf("%") != -1)
                {
                    percentageSize = true;
                }

                if (height != null && height.toString().indexOf("%") != -1)
                {
                    percentageSize = true;
                }
                if (percentageSize)
                {
                    if (!this.watchedElementData)
                    {
                        this.watchedElementData = [];
                    }
                    var that = this;
                    var checkForChanges = function (mutations)
                    {
                        if (that.watchedElementData.forEach)
                        {
                            that.watchedElementData.forEach(function (data)
                            {
                                if (data.element.offsetWidth !== data.offsetWidth ||
                                    data.element.offsetHeight !== data.offsetHeight)
                                {
                                    data.offsetWidth = data.element.offsetWidth;
                                    data.offsetHeight = data.element.offsetHeight;
                                    if (data.timer)
                                    {
                                        clearTimeout(data.timer);
                                    }
                                    data.timer = setTimeout(function ()
                                    {
                                        if (!$.jqx.isHidden($(data.element)))
                                        {
                                            data.callback();
                                        }
                                    });
                                }
                            });
                        }
                    };

                    that.watchedElementData.push({
                        element: element[0],
                        offsetWidth: element[0].offsetWidth,
                        offsetHeight: element[0].offsetHeight,
                        callback: callback
                    });
                    if (!that.observer)
                    {
                        that.observer = new MutationObserver(checkForChanges);
                        that.observer.observe(document.body, {
                            attributes: true,
                            childList: true,
                            characterData: true
                        });
                    }
                }
            }
            catch (er)
            {
            }
            if ($.jqx.isHidden(element) && checkForHidden === true) {
                doResize(true);
            }
            $.jqx.resize = function () {
                doResize(null, 'resize');
            }
        },

        html: function (element, value) {
            if (!$(element).on) {
                return $(element).html(value);
            }
            try {
                return $.access(element, function (value) {
                    var elem = element[0] || {},
                        i = 0,
                        l = element.length;

                    if (value === undefined) {
                        return elem.nodeType === 1 ?
                            elem.innerHTML.replace(rinlinejQuery, "") :
                            undefined;
                    }

                    var rnoInnerhtml = /<(?:script|style|link)/i,
                        nodeNames = "abbr|article|aside|audio|bdi|canvas|data|datalist|details|figcaption|figure|footer|" +
            "header|hgroup|mark|meter|nav|output|progress|section|summary|time|video",
                        rxhtmlTag = /<(?!area|br|col|embed|hr|img|input|link|meta|param)(([\w:]+)[^>]*)\/>/gi,
                        rtagName = /<([\w:]+)/,
                        rnocache = /<(?:script|object|embed|option|style)/i,
                        rnoshimcache = new RegExp("<(?:" + nodeNames + ")[\\s/>]", "i"),
                        rleadingWhitespace = /^\s+/,
                        wrapMap = {
                            option: [1, "<select multiple='multiple'>", "</select>"],
                            legend: [1, "<fieldset>", "</fieldset>"],
                            thead: [1, "<table>", "</table>"],
                            tr: [2, "<table><tbody>", "</tbody></table>"],
                            td: [3, "<table><tbody><tr>", "</tr></tbody></table>"],
                            col: [2, "<table><tbody></tbody><colgroup>", "</colgroup></table>"],
                            area: [1, "<map>", "</map>"],
                            _default: [0, "", ""]
                        };

                    if (typeof value === "string" && !rnoInnerhtml.test(value) &&
                        ($.support.htmlSerialize || !rnoshimcache.test(value)) &&
                        ($.support.leadingWhitespace || !rleadingWhitespace.test(value)) &&
                        !wrapMap[(rtagName.exec(value) || ["", ""])[1].toLowerCase()]) {

                        value = value.replace(rxhtmlTag, "<$1></$2>");

                        try {
                            for (; i < l; i++) {
                                elem = this[i] || {};
                                if (elem.nodeType === 1) {
                                    $.cleanData(elem.getElementsByTagName("*"));
                                    elem.innerHTML = value;
                                }
                            }

                            elem = 0;
                        } catch (e) { }
                    }

                    if (elem) {
                        element.empty().append(value);
                    }
                }, null, value, arguments.length);
            }
            catch (error) {
                return $(element).html(value);
            }
        },

        hasTransform: function (el) {
            var transform = "";
            transform = el.css('transform');

            if (transform == "" || transform == 'none') {
                transform = el.parents().css('transform');
                if (transform == "" || transform == 'none') {
                    var browserInfo = $.jqx.utilities.getBrowser();
                    if (browserInfo.browser == 'msie') {
                        transform = el.css('-ms-transform');
                        if (transform == "" || transform == 'none') {
                            transform = el.parents().css('-ms-transform');
                        }
                    }
                    else if (browserInfo.browser == 'chrome') {
                        transform = el.css('-webkit-transform');
                        if (transform == "" || transform == 'none') {
                            transform = el.parents().css('-webkit-transform');
                        }
                    }
                    else if (browserInfo.browser == 'opera') {
                        transform = el.css('-o-transform');
                        if (transform == "" || transform == 'none') {
                            transform = el.parents().css('-o-transform');
                        }
                    }
                    else if (browserInfo.browser == 'mozilla') {
                        transform = el.css('-moz-transform');
                        if (transform == "" || transform == 'none') {
                            transform = el.parents().css('-moz-transform');
                        }
                    }
                } else {
                    return transform != "" && transform != 'none';
                }
            }
            if (transform == "" || transform == 'none') {
                transform = $(document.body).css('transform');
            }
            return transform != "" && transform != 'none' && transform != null;
        },

        getBrowser: function () {
            var ua = navigator.userAgent.toLowerCase();

            var match = /(chrome)[ \/]([\w.]+)/.exec(ua) ||
		        /(webkit)[ \/]([\w.]+)/.exec(ua) ||
		        /(opera)(?:.*version|)[ \/]([\w.]+)/.exec(ua) ||
		        /(msie) ([\w.]+)/.exec(ua) ||
		        ua.indexOf("compatible") < 0 && /(mozilla)(?:.*? rv:([\w.]+)|)/.exec(ua) ||
		        [];

            var obj = {
                browser: match[1] || "",
                version: match[2] || "0"
            };
            if (ua.indexOf("rv:11.0") >= 0 && ua.indexOf(".net4.0c") >= 0) {
                obj.browser = "msie";
                obj.version = "11";
                match[1] = "msie";
            }
            if (ua.indexOf("edge") >= 0) {
                obj.browser = "msie";
                obj.version = "12";
                match[1] = "msie";
            }
            obj[match[1]] = match[1];
            return obj;
        }
    });
    $.jqx.browser = $.jqx.utilities.getBrowser();
    $.jqx.isHidden = function (element) {
        if (!element || !element[0])
            return false;

        var w = element[0].offsetWidth, h = element[0].offsetHeight;
        if (w === 0 || h === 0)
            return true;
        else {
            return false;
        }
    };

    $.jqx.ariaEnabled = true;
    $.jqx.aria = function (that, property, value) {
        if (!$.jqx.ariaEnabled)
            return;

        if (property == undefined) {
            $.each(that.aria, function (index, value) {
                var attrValue = !that.base ? that.host.attr(index) : that.base.host.attr(index);
                if (attrValue != undefined && !$.isFunction(attrValue)) {
                    var newValue = attrValue;
                    switch (value.type) {
                        case "number":
                            newValue = new Number(attrValue);
                            if (isNaN(newValue)) newValue = attrValue;
                            break;
                        case "boolean":
                            newValue = attrValue == "true" ? true : false;
                            break;
                        case "date":
                            newValue = new Date(attrValue);
                            if (newValue == "Invalid Date" || isNaN(newValue)) newValue = attrValue;
                            break;
                    }

                    that[value.name] = newValue;
                }
                else {
                    var attrValue = that[value.name];
                    if ($.isFunction(attrValue)) attrValue = that[value.name]();
                    if (attrValue == undefined) attrValue = "";
                    try {
                        !that.base ? that.host.attr(index, attrValue.toString()) : that.base.host.attr(index, attrValue.toString());
                    }
                    catch (error) {
                    }
                }
            });
        }
        else {
            try {
                if (that.host) {
                    if (!that.base) {
                        if (that.host) {
                            if (that.element.setAttribute) {
                                that.element.setAttribute(property, value.toString());
                            }
                            else {
                                that.host.attr(property, value.toString());
                            }
                        }
                        else {
                            that.attr(property, value.toString());
                        }
                    }
                    else {
                        if (that.base.host) {
                            that.base.host.attr(property, value.toString());
                        }
                        else {
                            that.attr(property, value.toString());
                        }
                    }
                }
                else if (that.setAttribute) {
                    that.setAttribute(property, value.toString());
                }
            }
            catch (error) {
            }
        }
    };

    if (!Array.prototype.indexOf) {
        Array.prototype.indexOf = function (elt /*, from*/) {
            var len = this.length;

            var from = Number(arguments[1]) || 0;
            from = (from < 0)
                ? Math.ceil(from)
                : Math.floor(from);
            if (from < 0)
                from += len;

            for (; from < len; from++) {
                if (from in this &&
                this[from] === elt)
                    return from;
            }
            return -1;
        };
    }

    $.jqx.mobile = $.jqx.mobile || {};
    $.jqx.position = function (event) {
        var left = parseInt(event.pageX);
        var top = parseInt(event.pageY);

        if ($.jqx.mobile.isTouchDevice()) {
            var touches = $.jqx.mobile.getTouches(event);
            var touch = touches[0];
            left = parseInt(touch.pageX);
            top = parseInt(touch.pageY);
        }
        return { left: left, top: top }
    }

    $.extend($.jqx.mobile,
    {
        _touchListener: function (e, me) {
            var createTouchEvent = function (name, e) {
                var event = document.createEvent('MouseEvents');

                event.initMouseEvent(
                    name,
                    e.bubbles,
                    e.cancelable,
                    e.view,
                    e.detail,
                    e.screenX,
                    e.screenY,
                    e.clientX,
                    e.clientY,
                    e.ctrlKey,
                    e.altKey,
                    e.shiftKey,
                    e.metaKey,
                    e.button,
                    e.relatedTarget
                );
                event._pageX = e.pageX;
                event._pageY = e.pageY;

                return event;
            }

            var eventMap = { 'mousedown': 'touchstart', 'mouseup': 'touchend', 'mousemove': 'touchmove' };
            var event = createTouchEvent(eventMap[e.type], e);
            e.target.dispatchEvent(event);

            var fn = e.target['on' + eventMap[e.type]];
            if (typeof fn === 'function') fn(e);
        },

        setMobileSimulator: function (element, value) {
            if (this.isTouchDevice()) {
                return;
            }

            this.simulatetouches = true;
            if (value == false) {
                this.simulatetouches = false;
            }

            var eventMap = { 'mousedown': 'touchstart', 'mouseup': 'touchend', 'mousemove': 'touchmove' };

            var self = this;
            if (window.addEventListener) {
                var subscribeToEvents = function () {
                    for (var key in eventMap) {
                        if (element.addEventListener) {
                            element.removeEventListener(key, self._touchListener);
                            element.addEventListener(key, self._touchListener, false);
                        }

                        //  document.removeEventListener(key, self._touchListener);
                        //  document.addEventListener(key, self._touchListener, false);
                    }
                }

                if ($.jqx.browser.msie) {
                    subscribeToEvents();
                }
                else {
                    subscribeToEvents();
                }
            }
        },

        isTouchDevice: function () {
            if (this.touchDevice != undefined)
                return this.touchDevice;

            var txt = "Browser CodeName: " + navigator.appCodeName + "";
            txt += "Browser Name: " + navigator.appName + "";
            txt += "Browser Version: " + navigator.appVersion + "";
            txt += "Platform: " + navigator.platform + "";
            txt += "User-agent header: " + navigator.userAgent + "";

            if (txt.indexOf('Android') != -1)
                return true;

            if (txt.indexOf('IEMobile') != -1)
                return true;

            if (txt.indexOf('Windows Phone') != -1)
                return true;

            if (txt.indexOf('WPDesktop') != -1)
                return true;

            if (txt.indexOf('ZuneWP7') != -1)
                return true;

            if (txt.indexOf('BlackBerry') != -1 && txt.indexOf('Mobile Safari') != -1)
                return true;

            if (txt.indexOf('ipod') != -1)
                return true;

            if (txt.indexOf('nokia') != -1 || txt.indexOf('Nokia') != -1)
                return true;

            if (txt.indexOf('Chrome/17') != -1)
                return false;

            if (txt.indexOf('CrOS') != -1)
                return false;

            if (txt.indexOf('Opera') != -1 && txt.indexOf('Mobi') == -1 && txt.indexOf('Mini') == -1 && txt.indexOf('Platform: Win') != -1) {
                return false;
            }

            if (txt.indexOf('Opera') != -1 && txt.indexOf('Mobi') != -1 && txt.indexOf('Opera Mobi') != -1) {
                return true;
            }

            var deviceTypes = {
                ios: 'i(?:Pad|Phone|Pod)(?:.*)CPU(?: iPhone)? OS ',
                android: '(Android |HTC_|Silk/)',
                blackberry: 'BlackBerry(?:.*)Version\/',
                rimTablet: 'RIM Tablet OS ',
                webos: '(?:webOS|hpwOS)\/',
                bada: 'Bada\/'
            }

            // check for IPad, IPhone, IE and Chrome
            try {
                if (this.touchDevice != undefined)
                    return this.touchDevice;

                this.touchDevice = false;
                for (i in deviceTypes) {
                    if (deviceTypes.hasOwnProperty(i)) {
                        prefix = deviceTypes[i];
                        match = txt.match(new RegExp('(?:' + prefix + ')([^\\s;]+)'));
                        if (match) {
                            if (i.toString() == "blackberry") {
                                // handle touches through mouse pointer.
                                this.touchDevice = false;
                                return false;
                            }

                            this.touchDevice = true;
                            return true;
                        }
                    }
                }

                var userAgent = navigator.userAgent;
                if (navigator.platform.toLowerCase().indexOf('win') != -1) {
                    if (userAgent.indexOf('Windows Phone') >= 0 || userAgent.indexOf('WPDesktop') >= 0 || userAgent.indexOf('IEMobile') >= 0 || userAgent.indexOf('ZuneWP7') >= 0) {
                        this.touchDevice = true;
                        return true;
                    }
                    else {
                        if (userAgent.indexOf('Touch') >= 0) {
                            var supported = ('MSPointerDown' in window) || ('pointerdown' in window);
                            if (supported) {
                                this.touchDevice = true;
                                return true;
                            }
                            if (userAgent.indexOf('ARM') >= 0) {
                                this.touchDevice = true;
                                return true;
                            }

                            this.touchDevice = false;
                            return false;
                        }
                    }
                }

                if (navigator.platform.toLowerCase().indexOf('win') != -1) {
                    this.touchDevice = false;
                    return false;
                }
                if (('ontouchstart' in window) || window.DocumentTouch && document instanceof DocumentTouch) {
                    this.touchDevice = true;
                }
                return this.touchDevice;
            } catch (e) {
                this.touchDevice = false;
                return false;
            }
        },

        getLeftPos: function (inputObj) {
            var returnValue = inputObj.offsetLeft;
            while ((inputObj = inputObj.offsetParent) != null) {
                if (inputObj.tagName != 'HTML') {
                    returnValue += inputObj.offsetLeft;
                    if (document.all) returnValue += inputObj.clientLeft;
                }
            }
            return returnValue;
        },

        getTopPos: function (inputObj) {
            var returnValue = inputObj.offsetTop;
            var initialOffset = $(inputObj).coord();
            while ((inputObj = inputObj.offsetParent) != null) {
                if (inputObj.tagName != 'HTML') {
                    returnValue += (inputObj.offsetTop - inputObj.scrollTop);
                    if (document.all) returnValue += inputObj.clientTop;
                }
            }
            var agent = navigator.userAgent.toLowerCase();
            var wp8 = (agent.indexOf('windows phone') != -1 || agent.indexOf('WPDesktop') != -1 || agent.indexOf('ZuneWP7') != -1 || agent.indexOf('msie 9') != -1 || agent.indexOf('msie 11') != -1 || agent.indexOf('msie 10') != -1) && agent.indexOf('touch') != -1;
            if (wp8) {
                return initialOffset.top;
            }

            if (this.isSafariMobileBrowser()) {
                if (this.isSafari4MobileBrowser() && this.isIPadSafariMobileBrowser()) {
                    return returnValue;
                }
                if (agent.indexOf('version/7') != -1) {
                    return initialOffset.top;
                }
                if (agent.indexOf('version/6') != -1 || agent.indexOf('version/5') != -1) {
                    returnValue = returnValue + $(window).scrollTop();
                }
                if (/(Android.*Chrome\/[.0-9]* (!?Mobile))/.exec(navigator.userAgent))
                {
                    return returnValue + $(window).scrollTop();
                }
                if (/(Android.*Chrome\/[.0-9]* Mobile)/.exec(navigator.userAgent))
                {
                    return returnValue + $(window).scrollTop();
                }
 
                return initialOffset.top;
            }

            return returnValue;
        },

        isChromeMobileBrowser: function () {
            var agent = navigator.userAgent.toLowerCase();
            var result = agent.indexOf('android') != -1;
            return result;
        },

        isOperaMiniMobileBrowser: function () {
            var agent = navigator.userAgent.toLowerCase();
            var result = agent.indexOf('opera mini') != -1 || agent.indexOf('opera mobi') != -1;
            return result;
        },

        isOperaMiniBrowser: function () {
            var agent = navigator.userAgent.toLowerCase();
            var result = agent.indexOf('opera mini') != -1;
            return result;
        },

        isNewSafariMobileBrowser: function () {
            var agent = navigator.userAgent.toLowerCase();
            var result = agent.indexOf('ipad') != -1 || agent.indexOf('iphone') != -1 || agent.indexOf('ipod') != -1;
            result = result && (agent.indexOf('version/5') != -1);
            return result;
        },

        isSafari4MobileBrowser: function () {
            var agent = navigator.userAgent.toLowerCase();
            var result = agent.indexOf('ipad') != -1 || agent.indexOf('iphone') != -1 || agent.indexOf('ipod') != -1;
            result = result && (agent.indexOf('version/4') != -1);
            return result;
        },

        isWindowsPhone: function () {
            var agent = navigator.userAgent.toLowerCase();
            var result = (agent.indexOf('windows phone') != -1 || agent.indexOf('WPDesktop') != -1 || agent.indexOf('ZuneWP7') != -1 || agent.indexOf('msie 9') != -1 || agent.indexOf('msie 11') != -1 || agent.indexOf('msie 10') != -1 && agent.indexOf('touch') != -1);
            return result;
        },

        isSafariMobileBrowser: function () {
            var agent = navigator.userAgent.toLowerCase();
            if (/(Android.*Chrome\/[.0-9]* (!?Mobile))/.exec(navigator.userAgent))
            {
                return true;
            }
            if (/(Android.*Chrome\/[.0-9]* Mobile)/.exec(navigator.userAgent))
            {
                return true;
            }

            var result = agent.indexOf('ipad') != -1 || agent.indexOf('iphone') != -1 || agent.indexOf('ipod') != -1 || agent.indexOf('mobile safari') != -1;
            return result;
        },

        isIPadSafariMobileBrowser: function () {
            var agent = navigator.userAgent.toLowerCase();
            var result = agent.indexOf('ipad') != -1;
            return result;
        },

        isMobileBrowser: function () {
            var agent = navigator.userAgent.toLowerCase();
            var result = agent.indexOf('ipad') != -1 || agent.indexOf('iphone') != -1 || agent.indexOf('android') != -1;
            return result;
        },

        // Get the touch points from this event
        getTouches: function (e) {
            if (e.originalEvent) {
                if (e.originalEvent.touches && e.originalEvent.touches.length) {
                    return e.originalEvent.touches;
                } else if (e.originalEvent.changedTouches && e.originalEvent.changedTouches.length) {
                    return e.originalEvent.changedTouches;
                }
            }

            if (!e.touches) {
                e.touches = new Array();
                e.touches[0] = e.originalEvent != undefined ? e.originalEvent : e;

                if (e.originalEvent != undefined && e.pageX)
                    e.touches[0] = e;
                if (e.type == 'mousemove') e.touches[0] = e;
            }

            return e.touches;
        },

        getTouchEventName: function (name) {
            if (this.isWindowsPhone()) {

                var agent = navigator.userAgent.toLowerCase();
                if (agent.indexOf('windows phone 7') != -1) {
                    if (name.toLowerCase().indexOf('start') != -1) return 'MSPointerDown';
                    if (name.toLowerCase().indexOf('move') != -1) return 'MSPointerMove';
                    if (name.toLowerCase().indexOf('end') != -1) return 'MSPointerUp';
                }
                if (name.toLowerCase().indexOf('start') != -1) return 'pointerdown';
                if (name.toLowerCase().indexOf('move') != -1) return 'pointermove';
                if (name.toLowerCase().indexOf('end') != -1) return 'pointerup';
            }
            else {
                return name;
            }
        },

        // Dispatches a fake mouse event from a touch event
        dispatchMouseEvent: function (name, touch, target) {
            if (this.simulatetouches)
                return;

            var e = document.createEvent('MouseEvent');
            e.initMouseEvent(name, true, true, touch.view, 1, touch.screenX, touch.screenY, touch.clientX, touch.clientY, false, false, false, false, 0, null);
            if (target != null) {
                target.dispatchEvent(e);
            }
        },

        // Find the root node of this target
        getRootNode: function (target) {
            while (target.nodeType !== 1) {
                target = target.parentNode;
            }
            return target;
        },

        setTouchScroll: function (enable, key) {
            if (!this.enableScrolling) this.enableScrolling = [];
            this.enableScrolling[key] = enable;
        },

        touchScroll: function (element, scrollHeight, callback, key, horizontalScroll, verticalScroll) {
            if (element == null)
                return;

            var me = this;
            var scrollY = 0;
            var touchY = 0;
            var movedY = 0;
            var scrollX = 0;
            var touchX = 0;
            var movedX = 0;
            if (!this.scrolling) this.scrolling = [];
            this.scrolling[key] = false;
            var moved = false;
            var $element = $(element);
            var touchTags = ['select', 'input', 'textarea'];
            var touchStart = 0;
            var touchEnd = 0;
            if (!this.enableScrolling) this.enableScrolling = [];
            this.enableScrolling[key] = true;
            var key = key;
            var touchStartName = this.getTouchEventName('touchstart') + ".touchScroll";
            var touchEndName = this.getTouchEventName('touchend') + ".touchScroll";
            var touchMoveName = this.getTouchEventName('touchmove') + ".touchScroll";

      //      horizontalScroll.fadeOut(0);
      //      verticalScroll.fadeOut(0);

            var view, indicator, relative,
               xmax, min, max, offset, reference, pressed, xform,
               velocity, frame, timestamp, ticker,
               amplitude, target, xtarget, xreference, timeConstant;
            max = scrollHeight;
            min = 0;
            offset = 0;
            xoffset = 0;
            xmax = horizontalScroll.jqxScrollBar('max');
            timeConstant = 325; // ms

            function ypos(e)
            {
                // touch event
                if (e.targetTouches && (e.targetTouches.length >= 1))
                {
                    return e.targetTouches[0].clientY;
                }
                else if (e.originalEvent && e.originalEvent.clientY !== undefined)
                {
                    return e.originalEvent.clientY;
                }
                else
                {
                    var touches = me.getTouches(e);
                    return touches[0].clientY;
                }

                // mouse event
                return e.clientY;
            }

            function xpos(e)
            {
                // touch event
                if (e.targetTouches && (e.targetTouches.length >= 1))
                {
                    return e.targetTouches[0].clientX;
                }
                else if (e.originalEvent && e.originalEvent.clientX !== undefined)
                {
                    return e.originalEvent.clientX;
                }
                else
                {
                    var touches = me.getTouches(e);
                    return touches[0].clientX;
                }

                // mouse event
                return e.clientX;
            }

            var track = function()
            {
                var now, elapsed, delta, v;

                now = Date.now();
                elapsed = now - timestamp;
                timestamp = now;
                delta = offset - frame;
                xdelta = xoffset - xframe;
                frame = offset;
                xframe = xoffset;
                pressed = true;
                v = 1000 * delta / (1 + elapsed);
                xv = 1000 * xdelta / (1 + elapsed);
                velocity = 0.8 * v + 0.2 * velocity;
                xvelocity = 0.8 * xv + 0.2 * xvelocity;
            }

            var touchStart = function (event) {
                if (!me.enableScrolling[key])
                    return true;

                // Allow certain HTML tags to receive touch events
                if ($.inArray(event.target.tagName.toLowerCase(), touchTags) !== -1) {
                    return;
                }
                offset = verticalScroll.jqxScrollBar('value');
                xoffset = horizontalScroll.jqxScrollBar('value');

                var touches = me.getTouches(event);
                var touch = touches[0];
                if (touches.length == 1) {
                    me.dispatchMouseEvent('mousedown', touch, me.getRootNode(touch.target));
                }

                function tap(e)
                {
                    pressed = true;
                    reference = ypos(e);
                    xreference = xpos(e);
                    velocity = amplitude = xvelocity = 0;
                    frame = offset;
                    xframe = xoffset;
                    timestamp = Date.now();
                    clearInterval(ticker);
                    ticker = setInterval(track, 100);

                    e.preventDefault();
                 //   e.stopPropagation();
                   // return false;
                }

                tap(event);
                moved = false;
                touchY = touch.pageY;
                touchX = touch.pageX;
                if (me.simulatetouches) {
                    if (touch._pageY != undefined) {
                        touchY = touch._pageY;
                        touchX = touch._pageX;
                    }
                }
                me.scrolling[key] = true;
                xmax = horizontalScroll.jqxScrollBar('max');
                max = verticalScroll.jqxScrollBar('max');
                scrollY = 0;
                scrollX = 0;
                return true;
            }

            if ($element.on) {
                $element.on(touchStartName, touchStart);
            }
            else {
                $element.bind(touchStartName, touchStart);
            }

            var scroll = function(top, event)
            {
                offset = (top > max) ? max : (top < min) ? min : top;           
                callback(null, top, 0, 0, event);
            }

            var hscroll = function (left, event)
            {
                xoffset = (left > xmax) ? xmax : (left < min) ? min : left;
                callback(left, null, 0, 0, event);
            }

            function autoScroll()
            {
                var elapsed, delta;
                if (amplitude)
                {
                    elapsed = Date.now() - timestamp;
                    delta = -amplitude * Math.exp(-elapsed / timeConstant);
                    if (delta > 0.5 || delta < -0.5)
                    {
                        scroll(target + delta, event);
                        requestAnimationFrame(autoScroll);
                    } else
                    {
                        scroll(target);
                        verticalScroll.fadeOut('fast');
                    }
                }
            }
            function hAutoScroll()
            {
                var elapsed, delta;
                if (amplitude)
                {
                    elapsed = Date.now() - timestamp;
                    delta = -amplitude * Math.exp(-elapsed / timeConstant);
                    if (delta > 0.5 || delta < -0.5)
                    {
                        hscroll(xtarget + delta);
                        requestAnimationFrame(hAutoScroll);
                    } else
                    {
                        hscroll(xtarget);
                        horizontalScroll.fadeOut('fast');
                    }

                }
            }
            var touchMove = function (event) {
                if (!me.enableScrolling[key])
                    return true;

                if (!me.scrolling[key]) {
                    return true;
                }
                var touches = me.getTouches(event);
                if (touches.length > 1) {
                    return true;
                }

                var pageY = touches[0].pageY;
                var pageX = touches[0].pageX;

                if (me.simulatetouches) {
                    if (touches[0]._pageY != undefined) {
                        pageY = touches[0]._pageY;
                        pageX = touches[0]._pageX;
                    }
                }

                var dy = pageY - touchY;
                var dx = pageX - touchX;
                touchEnd = pageY;
                touchHorizontalEnd = pageX;
                movedY = dy - scrollY;
                movedX = dx - scrollX;
                moved = true;
                scrollY = dy;
                scrollX = dx;

                var hScrollVisible = horizontalScroll != null ? horizontalScroll[0].style.visibility != 'hidden' : true;
                var vScrollVisible = verticalScroll != null ? verticalScroll[0].style.visibility != 'hidden' : true;


                function drag(e)
                {
                    var y, delta, x;
                    if (pressed)
                    {
                        y = ypos(e);
                        x = xpos(e);
                        delta = reference - y;
                        xdelta = xreference - x;
                        if (delta > 2 || delta < -2)
                        {
                            reference = y;
                            scroll(offset + delta, e);
                            track();
                            e.preventDefault();
                            e.stopPropagation();
                            return false;
                        }
                        else
                        {
                            if (xdelta > 2 || xdelta < -2)
                            {
                                xreference = x;
                                hscroll(xoffset + xdelta, e);
                                track();
                                e.preventDefault();
                                e.stopPropagation();
                                return false;
                            }
                        }
                        e.preventDefault();
                    }
                }

                if (hScrollVisible || vScrollVisible) {
                    if ((hScrollVisible) || (vScrollVisible)) {
                        drag(event);

                        //      callback(-movedX * 1, -movedY * 1, dx, dy, event);
                        //event.preventDefault();
                        //event.stopPropagation();
                        //if (event.preventManipulation) {
                        //    event.preventManipulation();
                        //}
                        //return false;
                    }
                }
            }

            if ($element.on) {
                $element.on(touchMoveName, touchMove);
            }
            else $element.bind(touchMoveName, touchMove);

   

            var touchCancel = function (event) {
                if (!me.enableScrolling[key])
                    return true;

                var touch = me.getTouches(event)[0];
                if (!me.scrolling[key]) {
                    return true;
                }
           

                pressed = false;
                clearInterval(ticker);
                if (velocity > 10 || velocity < -10)
                {
                    amplitude = 0.8 * velocity;
                    target = Math.round(offset + amplitude);
                    timestamp = Date.now();
                    requestAnimationFrame(autoScroll);
                    verticalScroll.fadeIn(100);
                }
                else if (xvelocity > 10 || xvelocity < -10)
                {
                    amplitude = 0.8 * xvelocity;
                    xtarget = Math.round(xoffset + amplitude);
                    timestamp = Date.now();
                    requestAnimationFrame(hAutoScroll);
                    horizontalScroll.fadeIn(100);
                }
                else
                {
                    horizontalScroll.fadeOut(100);
                    verticalScroll.fadeOut(100);
                }

                me.scrolling[key] = false;
                if (moved) {
                    me.dispatchMouseEvent('mouseup', touch, event.target);
                } else {
                    var touch = me.getTouches(event)[0],
						t = me.getRootNode(touch.target);

                    //        event.preventDefault();
                    //         event.stopPropagation();
                    // Dispatch fake mouse up and click events if this touch event did not move
                    me.dispatchMouseEvent('mouseup', touch, t);
                    me.dispatchMouseEvent('click', touch, t);
                    return true;
                }
            }

            if (this.simulatetouches)
            {
                var windowBindFunc = $(window).on != undefined || $(window).bind;
                var windowMouseUp = function (event)
                {
                    try
                    {
                        touchCancel(event);
                    }
                    catch (er)
                    {
                    }
                    me.scrolling[key] = false;
                };
                $(window).on != undefined ? $(document).on('mouseup.touchScroll', windowMouseUp) : $(document).bind('mouseup.touchScroll', windowMouseUp);

                if (window.frameElement)
                {
                    if (window.top != null)
                    {
                        var eventHandle = function (event)
                        {
                            try
                            {
                                touchCancel(event);
                            }
                            catch (er)
                            {
                            }
                            me.scrolling[key] = false;
                        };

                        if (window.top.document)
                        {
                            $(window.top.document).on ? $(window.top.document).on('mouseup', eventHandle) : $(window.top.document).bind('mouseup', eventHandle);
                        }
                    }
                }

                var docBindFunc = $(document).on != undefined || $(document).bind;
                var touchEndFunc = function (event)
                {
                    if (!me.scrolling[key])
                    {
                        return true;
                    }
                    me.scrolling[key] = false;
                    var touch = me.getTouches(event)[0],
						target = me.getRootNode(touch.target);

                    // Dispatch fake mouse up and click events if this touch event did not move
                    me.dispatchMouseEvent('mouseup', touch, target);
                    me.dispatchMouseEvent('click', touch, target);
                };

                $(document).on != undefined ? $(document).on('touchend', touchEndFunc) : $(document).bind('touchend', touchEndFunc);
            }

            if ($element.on) {
                $element.on('dragstart', function (event) {
                    event.preventDefault();
                });
                $element.on('selectstart', function (event) {
                    event.preventDefault();
                });
            }
            $element.on ? $element.on(touchEndName + ' touchcancel.touchScroll', touchCancel) : $element.bind(touchEndName + ' touchcancel.touchScroll', touchCancel);
        }
    });

    $.jqx.cookie = $.jqx.cookie || {};
    $.extend($.jqx.cookie,
    {
        cookie: function (key, value, options) {
            // set cookie.
            if (arguments.length > 1 && String(value) !== "[object Object]") {
                options = $.extend({}, options);

                if (value === null || value === undefined) {
                    options.expires = -1;
                }

                if (typeof options.expires === 'number') {
                    var days = options.expires, t = options.expires = new Date();
                    t.setDate(t.getDate() + days);
                }

                value = String(value);

                return (document.cookie = [
                encodeURIComponent(key), '=',
                options.raw ? value : encodeURIComponent(value),
                options.expires ? '; expires=' + options.expires.toUTCString() : '', // use expires attribute, max-age is not supported by IE
                options.path ? '; path=' + options.path : '',
                options.domain ? '; domain=' + options.domain : '',
                options.secure ? '; secure' : ''
        ].join(''));
            }
            // get cookie...
            options = value || {};
            var result, decode = options.raw ? function (s) { return s; } : decodeURIComponent;
            return (result = new RegExp('(?:^|; )' + encodeURIComponent(key) + '=([^;]*)').exec(document.cookie)) ? decode(result[1]) : null;
        }
    });

    // stringutilities
    $.jqx.string = $.jqx.string || {};
    $.extend($.jqx.string,
    {
        replace: function (text, stringToFind, stringToReplace) {
            if (stringToFind === stringToReplace) return this;
            var temp = text;
            var index = temp.indexOf(stringToFind);
            while (index != -1) {
                temp = temp.replace(stringToFind, stringToReplace);
                index = temp.indexOf(stringToFind);
            }
            return temp;
        },

        contains: function (fullString, value) {
            if (fullString == null || value == null)
                return false;

            return fullString.indexOf(value) != -1;
        },

        containsIgnoreCase: function (fullString, value) {
            if (fullString == null || value == null)
                return false;

            return fullString.toString().toUpperCase().indexOf(value.toString().toUpperCase()) != -1;
        },

        equals: function (fullString, value) {
            if (fullString == null || value == null)
                return false;

            fullString = this.normalize(fullString);

            if (value.length == fullString.length) {
                return fullString.slice(0, value.length) == value;
            }

            return false;
        },

        equalsIgnoreCase: function (fullString, value) {
            if (fullString == null || value == null)
                return false;

            fullString = this.normalize(fullString);

            if (value.length == fullString.length) {
                return fullString.toUpperCase().slice(0, value.length) == value.toUpperCase();
            }

            return false;
        },

        startsWith: function (fullString, value) {
            if (fullString == null || value == null)
                return false;

            return fullString.slice(0, value.length) == value;
        },

        startsWithIgnoreCase: function (fullString, value) {
            if (fullString == null || value == null)
                return false;

            return fullString.toUpperCase().slice(0, value.length) == value.toUpperCase();
        },

        normalize: function (fullString) {
            if (fullString.charCodeAt(fullString.length - 1) == 65279) {
                fullString = fullString.substring(0, fullString.length - 1);
            }

            return fullString;
        },

        endsWith: function (fullString, value) {
            if (fullString == null || value == null)
                return false;

            fullString = this.normalize(fullString);
            return fullString.slice(-value.length) == value;
        },

        endsWithIgnoreCase: function (fullString, value) {
            if (fullString == null || value == null)
                return false;

            fullString = this.normalize(fullString);

            return fullString.toUpperCase().slice(-value.length) == value.toUpperCase();
        }
    });

    $.extend($.easing, {
        easeOutBack: function (x, t, b, c, d, s) {
            if (s == undefined) s = 1.70158;
            return c * ((t = t / d - 1) * t * ((s + 1) * t + s) + 1) + b;
        },
        easeInQuad: function (x, t, b, c, d) {
            return c * (t /= d) * t + b;
        },
        easeInOutCirc: function (x, t, b, c, d) {
            if ((t /= d / 2) < 1) return -c / 2 * (Math.sqrt(1 - t * t) - 1) + b;
            return c / 2 * (Math.sqrt(1 - (t -= 2) * t) + 1) + b;
        },
        easeInOutSine: function (x, t, b, c, d) {
            return -c / 2 * (Math.cos(Math.PI * t / d) - 1) + b;
        },
        easeInCubic: function (x, t, b, c, d) {
            return c * (t /= d) * t * t + b;
        },
        easeOutCubic: function (x, t, b, c, d) {
            return c * ((t = t / d - 1) * t * t + 1) + b;
        },
        easeInOutCubic: function (x, t, b, c, d) {
            if ((t /= d / 2) < 1) return c / 2 * t * t * t + b;
            return c / 2 * ((t -= 2) * t * t + 2) + b;
        },
        easeInSine: function (x, t, b, c, d) {
            return -c * Math.cos(t / d * (Math.PI / 2)) + c + b;
        },
        easeOutSine: function (x, t, b, c, d) {
            return c * Math.sin(t / d * (Math.PI / 2)) + b;
        },
        easeInOutSine: function (x, t, b, c, d) {
            return -c / 2 * (Math.cos(Math.PI * t / d) - 1) + b;
        }
    });
})(jqxBaseFramework);

(function ($) {
    $.extend($.event.special,
    {
        "close": { noBubble: true },
        "open": { noBubble: true },
        "cellclick": { noBubble: true },
        "rowclick": { noBubble: true },
        "tabclick": { noBubble: true },
        "selected": { noBubble: true },
        "expanded": { noBubble: true },
        "collapsed": { noBubble: true },
        "valuechanged": { noBubble: true },
        "expandedItem": { noBubble: true },
        "collapsedItem": { noBubble: true },
        "expandingItem": { noBubble: true },
        "collapsingItem": { noBubble: true }
    });

    $.fn.extend({
        ischildof: function (filter_string) {
            var parents = $(this).parents().get();

            for (var j = 0; j < parents.length; j++) {
                if (typeof filter_string != "string") {
                    var parent = parents[j];
                    if (filter_string !== undefined) {
                        if (parent == filter_string[0])
                            return true;
                    }
                }
                else {
                    if (filter_string !== undefined) {
                        if ($(parents[j]).is(filter_string)) {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    });

    $.fn.jqxProxy = function () {
        var widget = $(this).data().jqxWidget;
        var args = Array.prototype.slice.call(arguments, 0);
        var element = widget.element;
        if (!element) element = widget.base.element;
        return $.jqx.jqxWidgetProxy(widget.widgetName, element, args);
    }

    var originalVal = this.originalVal = $.fn.val;
    $.fn.val = function (value) {
        if (typeof value == 'undefined') {
            if ($(this).hasClass('jqx-widget')) {
                var widget = $(this).data().jqxWidget;
                if (widget && widget.val) {
                    return widget.val();
                }
            }
            return originalVal.call(this);
        }
        else {
            if ($(this).hasClass('jqx-widget')) {
                var widget = $(this).data().jqxWidget;
                if (widget && widget.val) {
                    if (arguments.length != 2) {
                        return widget.val(value);
                    }
                    else {
                        return widget.val(value, arguments[1]);
                    }
                }
            }

            return originalVal.call(this, value);
        }
    };

    if ($.fn.modal && $.fn.modal.Constructor) {
        $.fn.modal.Constructor.prototype.enforceFocus = function () {
            $(document)
              .off('focusin.bs.modal') // guard against infinite focus loop
              .on('focusin.bs.modal', $.proxy(function (e) {
                  if (this.$element[0] !== e.target && !this.$element.has(e.target).length) {
                      if ($(e.target).parents().hasClass('jqx-popup'))
                          return true;
                      this.$element.trigger('focus')
                  }
              }, this));
        }
    }

    $.fn.coord = function (options) {
        var docElem, win,
            box = { top: 0, left: 0 },
            elem = this[0],
            doc = elem && elem.ownerDocument;
        if (!doc) {
            return;
        }
        docElem = doc.documentElement;
        if (!$.contains(docElem, elem)) {
            return box;
        }
        if (typeof elem.getBoundingClientRect !== undefined) {
            box = elem.getBoundingClientRect();
        }
        var getWindow = function(elem) {
            return $.isWindow(elem) ?
                elem :
                elem.nodeType === 9 ?
                    elem.defaultView || elem.parentWindow :
                    false;
        };

        win = getWindow(doc);
        var additionalLeftOffset = 0;
        var additionalTopOffset = 0;
        var agent = navigator.userAgent.toLowerCase();
        var result = agent.indexOf('ipad') != -1 || agent.indexOf('iphone') != -1;
        if (result) {
            // fix for iphone/ipad left offsets.
            additionalLeftOffset = 2;
        }
        if (true == options) {
            if ($(document.body).css('position') != 'static') {
                var coords = $(document.body).coord();
                additionalLeftOffset = -coords.left;
                additionalTopOffset = -coords.top;
            }
        }

        return {
            top: additionalTopOffset + box.top + (win.pageYOffset || docElem.scrollTop) - (docElem.clientTop || 0),
            left: additionalLeftOffset + box.left + (win.pageXOffset || docElem.scrollLeft) - (docElem.clientLeft || 0)
        };
    };
})(jqxBaseFramework);
