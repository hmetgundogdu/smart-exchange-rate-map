import { VectorMap } from '@south-paw/react-vector-maps';
// assets
import world from '../../assets/world.json';
// hooks
import useFocusLabel from './useFocusLabel';
// styles
import styled from 'styled-components';

const MapContainer = styled.div`
    width: 1000px;

    #label {
        position: absolute;
        top: 0;
        left: 0;
        display: none;
    }

    svg {
        stroke: #fff;
        path {
          fill: #a82b2b;
          cursor: pointer;
          outline: none;
    
          // When a layer is hovered
          &:hover {
            fill: rgba(168,43,43,0.83);
          }
    
          // When a layer is focused.
          &:focus {
            fill: rgba(168,43,43,0.6);
          }
    
          // When a layer is 'checked' (via checkedLayers prop).
          &[aria-checked='true'] {
            fill: rgba(56,43,168,1);
          }
    
          // When a layer is 'selected' (via currentLayers prop).
          &[aria-current='true'] {
            fill: rgba(56,43,168,0.83);
          }
    
          // You can also highlight a specific layer via it's id
          &[id="nz-can"] {
            fill: rgba(56,43,168,0.6);
          }
        }
    }
`;

interface CurrencyExchangeMapProps { }

function CurrencyExchangeMap(props: CurrencyExchangeMapProps) {

    const { focusLabelStyle, handleLayerClick } = useFocusLabel();

    return (
        <MapContainer>
            <div style={focusLabelStyle} id="label">
                1 dolar equals 10 lira
            </div>
            <VectorMap
                {...world}
                layerProps={{ onClick: handleLayerClick }}
            />
        </MapContainer>
    );
}

export default CurrencyExchangeMap;