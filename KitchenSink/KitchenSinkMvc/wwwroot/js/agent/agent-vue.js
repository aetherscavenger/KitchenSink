

var v = new Vue({
	el: "#agents",
	data: {
		agents:[]
	},
	mounted: function () {
		var instance = this;
		$.ajax({
			method: "GET"
			, url: "/agent/getdata"
		}).done(function (data) {
			instance.agents = data;
		});
	}
});