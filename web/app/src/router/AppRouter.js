import React from 'react';
import { 
    BrowserRouter as Router,
    Switch,
    Redirect
} from 'react-router-dom';
import { FoodTruckScreen } from '../components/index/FoodTruckScreen';
import { PublicRoute } from './PublicRoute';

export const AppRouter = () => {
    return (
        <Router>
            <div>
                <Switch>
                    <PublicRoute
                        exact
                        path="/"
                        component={FoodTruckScreen}
                    />
                    <Redirect to="/" />
                </Switch>
            </div>
        </Router>
    )
}
