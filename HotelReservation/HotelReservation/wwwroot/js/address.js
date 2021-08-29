class Address extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            address: '923 Robie Street Halifax NS Canada',
            phone:'902-222-444'
        }
    }
    render() {
        return (
            <div>
                <img src="../images/logo.png" width="200px" />
                <img src="../images/address.png" width="30px" />
                <span>{this.state.address}</span>
                <img src="../images/phone.png" width="30px" />
                <span>{this.state.phone}</span>
            </div>
        )
    }
}
ReactDOM.render(<Address />, document.getElementById("address"));
