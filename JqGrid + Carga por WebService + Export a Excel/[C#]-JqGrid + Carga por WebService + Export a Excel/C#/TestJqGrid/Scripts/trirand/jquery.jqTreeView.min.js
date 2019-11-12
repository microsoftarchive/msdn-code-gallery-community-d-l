; (function($, window, document, undefined) {
	var pluginName = 'jqTreeView',
        defaults = {
        	id: "",
        	dataUrl: "",
        	nodes: [],
        	hoverOnMouseOver: true,
        	checkBoxes: false,
        	multipleSelect: false,
        	onExpand: null,
        	onCollapse: null,
        	onCheck: null,
        	onSelect: null,
        	onMouseOver: null,
        	onMouseOut: null
        },
        toggleActive = false;

	function TreeView(element, options) {
		this.self = $(element);
		this.options = $.extend({}, defaults, options);
		this.toggleActive = toggleActive;
		$(element).prop("treeview", this);
		this.self.addClass("ui-widget ui-widget-content ui-jqtreeview");
		
		if (this.options.nodes.length > 0) {			
			this.nodesLoaded(this.options.nodes);
		}
		else {
			this.loadNodes();
		}
	};

	TreeView.prototype.loadNodes = function() {		
		var that = this;

		$.ajax({
			url: this.options.dataUrl,
			type: "GET",
			success: this.executeInContext(this, this.nodesLoaded)
		});
	};
	
	TreeView.prototype.loadChildNodes = function(parentNodeValue, childElement, parentElement) {
		var that = this;
		var url = this.options.dataUrl + "?parentNodeValue=" + encodeURIComponent(parentNodeValue);
		var startElement = childElement ? childElement : this.self;

		$.ajax({
			url: url,
			type: "GET",
			success: function(json) {
				that.renderNodes($.parseJSON(json), startElement);
				that.serializeCheckedState();
				that.serializeSelectedState();
				that.serializeExpandedState();
				parentElement.trigger("expand");
			}
		});
	};

	TreeView.prototype.executeInContext = function(context, func) {
		return function() {
			func.apply(context, arguments);
		};
	};

	TreeView.prototype.nodesLoaded = function(json) {		
		var parsedJson = json;
		if (!$.isArray(json))		
			parsedJson = $.parseJSON(json)
		this.renderNodes(parsedJson, this.self);
		this.renderHiddenStateFields();
		this.attachEvents();
		this.serializeCheckedState();
		this.serializeSelectedState();
		this.serializeExpandedState();
	};
	
	TreeView.prototype.renderNode = function(nodeOptions, parent) {
		var nodeEnabled = true;
		if (typeof nodeOptions.enabled == "undefined")
			nodeEnabled = true;
		else if (!nodeOptions.enabled)
			nodeEnabled = false;

		var templateOptions = $.extend({
			expanded: nodeOptions.expanded ? true : false,
			selected: nodeOptions.selected ? true : false,
			enabled: nodeEnabled,
			loadOnDemand: nodeOptions.loadOnDemand ? true : false,
			expandedLiClass: nodeOptions.expanded ? "ui-jqtreeview-item-expanded" : "",
			url: nodeOptions.url ? "href=" + nodeOptions.url : "",
			tabindex: nodeOptions.selected ? 0 : -1,
			itemCssClass: getItemCssClass(nodeOptions),
			expandImageCssClass: this.getExpandImageCssClass(nodeOptions),
			initialDisplay: nodeOptions.expanded ? "block" : "none",
			initialImage: this.getCurrentNodeImage(nodeOptions),
			checkBoxes: this.options.checkBoxes,
			initialCheckedState: nodeOptions.checked ? "checked" : "",
			selectedCssClass: nodeOptions.selected ? "ui-state-highlight" : "",
			disabledItemTextClass: nodeEnabled ? "" : "ui-jqtreeview-item-text-disabled",
			showExpandImage: nodeOptions.nodes || nodeOptions.loadOnDemand,
			hovered: false	}, nodeOptions); 		

		var a = [];
		var t = templateOptions;
		a[a.length] = "<li class='ui-jqtreeview-item " + t.expandedLiClass + "'>";
		a[a.length] = "<a tabindex=" + t.tabindex + " " + t.url + " class='" + t.itemCssClass + "' onfocus='this.blur();'>";
		a[a.length] = "<table cellpadding=0 cellspacing=0 style='width:100%;' class='ui-helper-reset'>";
		a[a.length] = "<tr class='ui-jqtreeview-aref " + t.selectedCssClass + "'>";
		if (t.showExpandImage)
			a[a.length] = "<td valign=middle style='width:0px !important'><span class='ui-icon ui-jqtreeview-item-expand-image " + t.expandImageCssClass + "'></span></td>";
		if (t.checkBoxes)
			a[a.length] = "<td valign=middle style='width:21px;text-align:center;'><input type='checkbox' class='ui-jqtreeview-item-checkbox' " + t.initialCheckedState + "></input></td>";
		if (t.imageUrl)
			a[a.length] = "<td valign=middle style='width:21px;text-align:center;'><img class='ui-jqtreeview-item-image' src='" + t.initialImage + "' /></td>";
		a[a.length] = "<td valign=middle style='width:100%;'><span class='ui-jqtreeview-item-text " + t.disabledItemTextClass + "'>" + t.text +"</span></td>";
		a[a.length] = "</tr></table></a>";
		if (t.showExpandImage)
			a[a.length] = "<ul style='display:" + t.initialDisplay + "'></ul>";
		a[a.length] = "</li>";	
		var newNode = a.join("");
		newNode = $(newNode);
	
		var newParent = parent
							.append(newNode)
							.find("ul:last");
		newNode.data("options", templateOptions);

		if (nodeOptions.nodes) {
			this.renderNodes(nodeOptions.nodes, newParent);
		}

		function getItemCssClass(options) {
			var result = "";
			result = result.concat(" ui-corner-all ui-jqtreeview-aref");
			if (options.nodes) {
				result = result.concat(" ui-jqtreeview-parent");
				if (!options.expanded)
					result = result.concat(" ui-jqtreeview-parent-collapsed");
			}
			return result;
		};
	}; // end of doRenderNode 			

	TreeView.prototype.renderNodes = function(json, parent) {
		var that = this;
		$.each(json, function(index, options) {
			that.renderNode(options, parent);
		});
	};

	TreeView.prototype.renderHiddenStateFields = function() {
		var checkedID = this.getCheckedStateHiddenID();
		var selectedID = this.getSelectedStateHiddenID();
		var expandedID = this.getExpandedStateHiddenID();
		this.self.remove("#" + checkedID).append("<input type='hidden' id='" + checkedID + "' name='" + checkedID + "'></input>");
		this.self.remove("#" + selectedID).append("<input type='hidden' id='" + selectedID + "' name='" + selectedID + "'></input>");
		this.self.remove("#" + expandedID).append("<input type='hidden' id='" + expandedID + "' name='" + expandedID + "'></input>");
	};

	TreeView.prototype.getCheckedStateHiddenID = function() {
		return this.options.id + "_checkedState";
	};

	TreeView.prototype.getSelectedStateHiddenID = function() {
		return this.options.id + "_selectedState";
	};

	TreeView.prototype.getExpandedStateHiddenID = function() {
		return this.options.id + "_expandedState";
	};

	TreeView.prototype.serializeCheckedState = function() {
		var nodes = [];
		var that = this;
		$.each(this.self.find("input:checked"), function(i, checkbox) {
			nodes[nodes.length] = that.serializeNode(checkbox);
		});

		$("#" + this.getCheckedStateHiddenID()).val(JSON.stringify(nodes));
	};

	TreeView.prototype.serializeSelectedState = function() {
		var nodes = [];
		var that = this;
		$.each(this.self.find(".ui-state-highlight"), function(i, node) {
			nodes[nodes.length] = that.serializeNode(node);
		});

		$("#" + this.getSelectedStateHiddenID()).val(JSON.stringify(nodes));
	};

	TreeView.prototype.serializeExpandedState = function() {
		var nodes = [];
		var that = this;
		$.each(this.self.find(".ui-jqtreeview-item-expanded"), function(i, node) {
			nodes[nodes.length] = that.serializeNode(node);
		});

		$("#" + this.getExpandedStateHiddenID()).val(JSON.stringify(nodes));
	};

	TreeView.prototype.serializeNode = function(element) {		
		var options = this.getNodeOptions($(element));
		var node = new Object();
		if (options.text) node.text = options.text;
		if (options.value) node.value = options.value;
		if (options.checked) node.checked = true;
		if ($(element).hasClass("ui-state-highlight")) node.selected = true;

		return node;
	};

	TreeView.prototype.getNodeOptions = function(target) {
		return this.getNodeParentLiElement(target).data("options");
	};

	TreeView.prototype.getNodeParentLiElement = function(target) {
		return target.hasClass("ui-jqtreeview-item") ? target : target.parents("li:eq(0)");
	};

	TreeView.prototype.getNodeImageElement = function(target) {
		return this.getNodeParentLiElement(target).find(".ui-jqtreeview-item-image:eq(0)");
	};

	TreeView.prototype.getNodeCheckBoxElement = function(target) {
		return this.getNodeParentLiElement(target).find(".ui-jqtreeview-item-checkbox:eq(0)");
	};

	TreeView.prototype.getNodeTextElement = function(target) {
		return this.getNodeParentLiElement(target).find(".ui-jqtreeview-item-text:eq(0)");
	};

	TreeView.prototype.getNodeExpandImageElement = function(target) {
		return this.getNodeParentLiElement(target).find(".ui-jqtreeview-item-expand-image:eq(0)");
	};

	TreeView.prototype.getNodeChildUlElement = function(target) {
		return target.parents("a:eq(0)").next();
	};

	TreeView.prototype.getExpandImageCssClass = function(options) {
		return options.expanded ? "ui-icon-circlesmall-minus" : "ui-icon-circlesmall-plus";
	};

	TreeView.prototype.getCurrentNodeImage = function(options) {
		if (options.expandedImageUrl && options.expanded)
			return options.expandedImageUrl;
		if (options.imageUrl)
			return options.imageUrl;
	};

	TreeView.prototype.attachEvents = function() {
		this.self
			.bind('mouseover', this.executeInContext(this, this.handleMouseOver))
			.bind('mouseout', this.executeInContext(this, this.handleMouseOut))
			.bind('expand', this.executeInContext(this, this.handleExpand))
			.bind('collapse', this.executeInContext(this, this.handleCollapse))
			.bind('toggle', this.executeInContext(this, this.handleToggle))
			.bind('click', this.executeInContext(this, this.handleClick));
	};

	TreeView.prototype.handleMouseOver = function(event) {
		var target = $(event.target);
		var nodeOptions = this.getNodeOptions(target);
		if (nodeOptions.hovered) return;
		if (target.hasClass("ui-jqtreeview-item-expand-image")) return;

		if (this.options.hoverOnMouseOver) {
			if (nodeOptions.enabled) {
				nodeOptions.hovered = true;
				var row = $(target).parents("tr.ui-jqtreeview-aref:first");
				if (row) {
					$(row).addClass("ui-state-hover");
				}
			}
		}

		if (this.options.onMouseOver) {
			var node = this.getNodeParentLiElement(target);
			this.options.onMouseOver(node, event);
		}

		nodeOptions.hovered = true;
	};

	TreeView.prototype.handleMouseOut = function(event) {
		var target = $(event.target);
		var nodeOptions = this.getNodeOptions(target);

		if (this.options.hoverOnMouseOver) {
			this.self.find(".ui-state-hover").removeClass("ui-state-hover");
		}

		if (this.options.onMouseOut) {
			var node = this.getNodeParentLiElement(target);
			this.options.onMouseOut(node, event);
		}

		nodeOptions.hovered = false;
	};

	TreeView.prototype.handleExpand = function(event) {
		if (!this.toggleActive) {
			var target = $(event.target);
			var options = this.getNodeOptions(target);

			if (options.enabled) {
				options.expanded = true;


				if (this.options.onExpand) {
					var node = this.getNodeParentLiElement(target);
					var result = this.options.onExpand(node, event);
					if (result === false) {
						options.expanded = true;
						return;
					}
				}

				this.toggleActive = true;
				this.getNodeParentLiElement(target).addClass("ui-jqtreeview-item-expanded");
				target.removeClass("ui-icon-circlesmall-plus").addClass("ui-icon-circlesmall-minus");
				this.getNodeImageElement(target).attr("src", this.getCurrentNodeImage(options));
				this.getNodeChildUlElement(target).hide().slideDown(120, this.executeInContext(this, this.toggleEnded));
				this.serializeExpandedState();
			}
		}
	};

	TreeView.prototype.handleCollapse = function(event) {
		if (!this.toggleActive) {
			var target = $(event.target);
			var options = this.getNodeOptions(target);

			if (options.enabled) {
				options.expanded = false;

				if (this.options.onCollapse) {
					var node = this.getNodeParentLiElement(target);
					var result = this.options.onCollapse(node, event);
					if (result === false) {
						options.expanded = true;
						return;
					}
				}

				this.toggleActive = true;
				this.getNodeParentLiElement(target).removeClass("ui-jqtreeview-item-expanded");
				target.removeClass("ui-icon-circlesmall-minus").addClass("ui-icon-circlesmall-plus");
				this.getNodeImageElement(target).attr("src", this.getCurrentNodeImage(options));

				this.getNodeChildUlElement(target).slideUp(120, this.executeInContext(this, this.toggleEnded));
				this.serializeExpandedState();
			}
		}
	};

	TreeView.prototype.toggleEnded = function() {
		this.toggleActive = false;
	};

	TreeView.prototype.handleToggle = function(event) {
		var target = $(event.target);
		var nodeOptions = this.getNodeOptions(target);
		var expanded = nodeOptions.expanded;

		if (nodeOptions.loadOnDemand && !expanded) {
			var childElement = this.getNodeChildUlElement(target);
			this.loadChildNodes(nodeOptions.value, childElement, target);
			return;
		}

		expanded ? target.trigger('collapse') : target.trigger('expand');
	};

	TreeView.prototype.handleClick = function(event) {
		var target = $(event.target);
		var node = this.getNodeParentLiElement(target);
		var nodeOptions = this.getNodeOptions(target);

		if (target.hasClass("ui-jqtreeview-item-checkbox")) {
			if (this.options.onCheck) {
				nodeOptions.checked = target.prop("checked");
				var result = this.options.onCheck(node, event);
				if (result === false) {
					return false;
				}
			}
			this.serializeCheckedState();
			return;
		}
		if (target.hasClass('ui-jqtreeview-item-expand-image')) {			
			this.handleToggle(event);
			return false;
		}

		if (!(this.options.multipleSelect && event.ctrlKey)) {
			this.unSelectAll();
		}

		this.select(target, event);
	};

	TreeView.prototype.getNodeByText = function(text) {
		return this.self.find(".ui-jqtreeview-item-text:contains('" + text + "'):eq(0)");
	};

	TreeView.prototype.getNodeByValue = function(value) {
		var that = this;
		that.resultNode = null;
		var nodes = this.self.find(".ui-jqtreeview-item-text");
		$.each(nodes, function(index, node) {
			if (that.getNodeOptions($(node)).value == value) {
				that.resultNode = $(node);
				return false;
			}
		});

		return that.resultNode;
	};

	TreeView.prototype.getAllNodes = function() {
		return this.self.find(".ui-jqtreeview-item");
	};

	TreeView.prototype.check = function(node, event) {
		node = $(node);
		var checkBox = this.getNodeCheckBoxElement(node);
		if (checkBox) {
			this.getNodeOptions(node).checked = true;
			checkBox.prop("checked", true);
			this.serializeCheckedState();
		}
	};

	TreeView.prototype.unCheck = function(node) {
		node = $(node);
		var checkBox = this.getNodeCheckBoxElement(node);
		if (checkBox) {
			this.getNodeOptions(node).checked = false;
			checkBox.prop("checked", false);
			this.serializeCheckedState();
		}
	};

	TreeView.prototype.expand = function(node) {
		node.trigger('expand');
	};

	TreeView.prototype.collapse = function(node) {
		node.trigger('collapse');
	};

	TreeView.prototype.toggle = function(node) {
		node.trigger('toggle');
	};

	TreeView.prototype.expandAll = function() {
		this.self.find(".ui-jqtreeview-item-expand-image").trigger("expand");
	};

	TreeView.prototype.collapseAll = function() {
		this.self.find(".ui-jqtreeview-item-expand-image").trigger("collapse");
	};

	TreeView.prototype.select = function(node, event) {
		var nodeOptions = this.getNodeOptions(node);		
		if (nodeOptions.enabled) {
			if (this.options.onSelect) {
				var result = this.options.onSelect(node, event);
				if (result === false)
					return;
			}

			var row = $(node).parents("tr.ui-jqtreeview-aref:first");
			if (row) {			
				$(row).addClass("ui-state-highlight");
			}

			this.serializeSelectedState();
		}
	};

	TreeView.prototype.unSelect = function(node) {
		var row = $(node).parents("tr.ui-jqtreeview-aref:first");
		if (row) {
			$(row).removeClass("ui-state-highlight");
		}

		this.serializeSelectedState();
	};

	TreeView.prototype.unSelectAll = function() {
		this.self.find(".ui-state-highlight").removeClass("ui-state-highlight");

		this.serializeSelectedState();
	};

	$.fn[pluginName] = function(options) {
		return this.each(function() {
			if (!$.data(this, 'plugin_' + pluginName)) {
				$.data(this, 'plugin_' + pluginName, new TreeView(this, options));
			}
		});
	};

	$.fn["getTreeViewInstance"] = function() {
		return $(this).prop("treeview");
	};

})(jQuery, window, document);