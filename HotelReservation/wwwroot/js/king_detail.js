var priceStyle = {
    fontSize: 30,
};
class Kingdetail extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            address: '923 Robie Street Halifax NS Canada',
            phone: '902-222-444'
        }
    }
    render() {
        return (
            <div>
                <div className="header">
                <img src="../images/logo.png" width="200px" />
                <img src="../images/address.png" width="30px" />
                <span>{this.state.address}</span>
                <img src="../images/phone.png" width="30px" />
                    <span>{this.state.phone}</span>
                </div>
                <div>
                    <h1>Guest Room 1 King</h1>
                    <p>From <b style={priceStyle}>180 </b><b>CAD/night</b></p>
                    <img src="../images/big_king.png" width="1000px" />
                </div>
            </div>
        )
    }
}
ReactDOM.render(<Kingdetail />, document.getElementById("roomdetail"));