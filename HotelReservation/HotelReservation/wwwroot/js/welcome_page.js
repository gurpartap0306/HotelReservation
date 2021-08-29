class App extends React.Component {
    constructor(props) {
        super(props)
    }
    render() {
        return (
            <div>
                <img src="../images/header.png" width="1000px"/>
                <img src="../images/hotel.png" width="1000px" />
            </div>
        )
    }
}
ReactDOM.render(<App />, document.getElementById("home"))