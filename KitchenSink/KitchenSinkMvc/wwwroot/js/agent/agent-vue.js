/*
 * Bleh, monolithic. Maintenence is going to be high in this section.
 * Really should split out these into components. I've spent enough time on this exercise though. KISS it for now.
 * 
 **/

var v = new Vue({
	el: "#agents",
	data() {
		return {
			agents: [],
			agentCustomers: [],
			creatingNewAgent: false,
			creatingNewCustomer: false,
			selectedAgent: { _id: null },
			peekCustomers: { _id: null },
			selectedCustomer: { _id: null, editing: false }
		};
	},
	methods: {
		addTag: function () {
			this.$data.selectedCustomer.tags.push("newTag");
		},
		cancelEdit: function () {
			this.$data.selectedAgent.editing = false;
			this.$data.selectedAgent = { _id: null };
		},
		cancelCustEdit: function () {
			this.$data.selectedCustomer.editing = false;
			this.$data.selectedCustomer = { _id: null };
		},
		cancelPeek: function () {
			this.$data.agentCustomers = [];
			this.$data.peekCustomers = { _id: null };
			this.$data.selectedCustomer.editing = false;
			this.$data.selectedCustomer = { _id: null };
		},
		deleteCust: function (cust) {
			var self = this;
			$.ajax({
				method: "DELETE"
				, url: "/customer/deletedata"
				, data: cust
			}).done(function (data) {
				self.cancelPeek();
			});
		},
		editRow: function (agent) {
			agent.editing = true;
		},
		editCustRow: function (cust) {
			cust.editing = true;
		},
		newAgent: function () {
			this.$data.creatingNewAgent = true;
			this.$data.selectedAgent = {
				_id: 0, displayName: null, address: {}, phones: [{ typeDisplay: "Pr", type: 0 }, { typeDisplay: "Mo", type: 2 }], editing: true
			};
		},
		newCustomer: function () {
			var self = this;
			this.$data.creatingNewCustomer = true;
			this.$data.selectedCustomer = {
				agent: self.$data.peekCustomers,
				_id: 0
				, address: [{ key: 0, value: {} }]
				, balance: 0
				, characteristics: [{ key: "Age", value: 0 }
					, { key: "EyeColor", value: "" }]
				, emails: [{ type: 0 }]
				, isActive: true
				, lastMobileLocation: { latitude: 0, longitude: 0 }
				, phones: [{ type: 0 }]
				, tags: []
				, editing: true
			};
		},
		saveEdit: function (agent) {
			var self = this;
			$.ajax({
				method: "POST"
				, url: "/agent/savedata"
				, data: agent
			}).done(function (data) {
				if (self.$data.creatingNewAgent) {
					self.$data.agents.push(data);
					self.$data.creatingNewAgent = false;
					self.$data.selectedAgent = { _id: null };
				}
				else {
					self.cancelEdit();
				}
			});
		},
		saveCustEdit: function (cust) {
			var self = this;
			$.ajax({
				method: "POST"
				, url: "/customer/savedata"
				, data: cust
			}).done(function (data) {
				if (self.$data.creatingNewCustomer) {
					self.cancelPeek();
				}
				else {
					self.cancelCustEdit();
				}
			});
		},
		showRow: function (agent) {
			this.$data.selectedAgent = agent;
		},
		showCustRow: function (customer) {
			this.$data.selectedCustomer = customer;
		},
		viewCustomers: function (event, agent) {
			var self = this;
			$.ajax({
				method: "GET"
				, url: "/agent/getcustomers"
				, data: agent
			}).done(function (data) {
				for (var i = 0; i < data.length; i++) {
					data[i].editing = false;
					data[i].movedAgents = false;
				}
				self.$data.agentCustomers = data;
				self.$data.peekCustomers = agent;
			});
		}
	},
	mounted: function () {
		var instance = this;
		$.ajax({
			method: "GET"
			, url: "/agent/getdata"
		}).done(function (data) {
			for (var i = 0; i < data.length; i++) {
				data[i].editing = false;
			}
			instance.agents = data;
		});
	}
});