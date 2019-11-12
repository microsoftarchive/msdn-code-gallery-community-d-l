var App = React.createClass({

		getInitialState: function(){
			return{data: []};
		},

		componentWillMount: function(){
		var xhr = new XMLHttpRequest();
		xhr.open('get', this.props.url, true);
		xhr.onload = function() {
		  var webAPIData = JSON.parse(xhr.responseText);

		  this.setState({ data: webAPIData });
		}.bind(this);
		xhr.send();
	},

        render: function(){
            return (

                <h2>{this.state.data}</h2>
            );
        }
});

React.render(<App url="/Home/GetMessage" />, document.getElementById('reactContent'));
