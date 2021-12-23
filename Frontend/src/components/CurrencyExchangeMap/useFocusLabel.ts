import { useMemo, useState } from "react";

export default function useFocusLabel() {
    const [selected, setSelected] = useState<string | null>(null);

    const handleLayerClick = ({ target }: MouseEvent) => {
        const targetEl = target as HTMLElement;
        const id = targetEl.attributes.getNamedItem('id')?.value;

        if (typeof id !== 'string')
            return;

        setSelected((currentId) => currentId === id ? null : id);
    };

    const focusLabelStyle = useMemo(() => {
        if (selected === null)
            return {};

        const selectedEl = document.getElementById(selected);
        const selectedElRect = selectedEl?.getBoundingClientRect();

        if (!selectedElRect)
            return {};

        const top = (selectedElRect.top + selectedElRect.bottom) / 2;
        const left = (selectedElRect.left + selectedElRect.right) / 2;

        return {
            display: 'block',
            top,
            left,
        };
    }, [selected]);

    return {
        selected,
        focusLabelStyle,
        handleLayerClick,
    }
}