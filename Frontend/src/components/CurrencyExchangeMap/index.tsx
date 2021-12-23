import { VectorMap } from '@south-paw/react-vector-maps';

import world from '../../assets/world.json';

interface CurrencyExchangeMapProps {

}

function CurrencyExchangeMap(props: CurrencyExchangeMapProps) {
    return (
        <VectorMap {...world} />
    );
}

export default CurrencyExchangeMap;