import { combineReducers } from 'redux';
import { uiReducer } from './uiReducer';
import { appReducer } from './appReducer';

export const rootReducer = combineReducers({
    ui: uiReducer,
    app: appReducer,
});
