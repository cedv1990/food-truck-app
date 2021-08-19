import { types } from '../types';

const initialState = {
    loading: false,
};

export const uiReducer = (state = initialState, action) => {
    switch (action.type) {
        case types.setLoading:
            return {
                ...state,
                loading: true,
            };
        case types.removeLoading:
            return {
                ...state,
                loading: false,
            };
        default:
            return state;
    }
};
