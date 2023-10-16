import axios from "axios";

class CandleStickService{
    Create(closePrice: number, openPrice: number, HighPrice: number, lowPrice: number)
    {
        axios.post('https://localhost:7223/api/CandleStickModel', {closePrice,openPrice,lowPrice,HighPrice})
        .then(() => window.location.reload())
        .catch(err => console.log(err.data))
    }
}

export default CandleStickService;