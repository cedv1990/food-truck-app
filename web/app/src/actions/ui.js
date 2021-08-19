import { types } from '../types';

export const uiLoading = () => ({
    type: types.setLoading,
});

export const uiLoadingEnd = () => ({
    type: types.removeLoading,
});
