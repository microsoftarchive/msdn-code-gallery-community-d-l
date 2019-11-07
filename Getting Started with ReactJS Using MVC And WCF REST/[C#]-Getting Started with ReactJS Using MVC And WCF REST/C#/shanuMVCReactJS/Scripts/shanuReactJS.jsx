var ItemDetailList = React.createClass({
    render: function() {
        
        var itemTable = this.props.data.map(function (itemarray) {

            return (
                               
              <ItemArray>

                   <table >
                    <tr >
                        <td width="40"></td>
                        <td width="140" align="center">
                            {itemarray.ItemID}
                        </td>
                        <td width="240" align="center" >
                            {itemarray.ItemName}
                        </td>
                        <td width="120" align="right" >
                            {itemarray.Price}   
                        </td>
                        <td width="420" align="center">
                            {itemarray.Desc}
                        </td>


                        <td></td>
                    </tr>
                   </table>
            

            </ItemArray>
           
          );
    });
return (
  <div >
      {itemTable}
  </div>
    );
}
});

var ItemArray = React.createClass({
    render: function() {       
        return (
          <div>
              {this.props.children}
          </div>
      );
    }
});

var ItemContainer = React.createClass({

    getInitialState: function(){
        return{data: []};
    },

    componentWillMount: function(){
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function() {
            var itemData = JSON.parse(xhr.responseText);

            this.setState({ data: itemData });
        }.bind(this);
        xhr.send();
    },

    render: function(){
        return(
         
             <ItemDetailList data={this.state.data} />
        );
    }
});

React.render(<ItemContainer url="http://localhost:39290/Service1.svc/getItemDetails/" />, document.getElementById('reactContent'));

 