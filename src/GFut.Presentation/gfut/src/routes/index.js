import React from 'react';
import { Switch, Redirect } from 'react-router-dom';

import { RouteWithLayout } from '~/components';
import { Main as MainLayout, Minimal as MinimalLayout } from '~/layouts';

import {
  Dashboard as DashboardView,
  PlayerList as PlayerListView,
  Player as PlayerView,
  PersonList as PersonListView,
  Person as PersonView,
  TeamList as TeamListView,
  Team as TeamView,
  FieldList as FieldListView,
  Field as FieldView, 
  FieldItemList as FieldItemListView,
  FieldItemField as FieldItemFieldListView,
  FieldItem as FieldItemView,  
  HoraryPrice as HoraryPriceView, 
  HoraryPriceFieldList as HoraryPriceFieldListView,  
  HoraryPriceList as HoraryPriceListView,
  HoraryField as HoraryFieldView,   
  HoraryFieldFieldList as HoraryFieldFieldListView,
  HoraryFieldList as HoraryFieldListView, 
  HoraryExtraField as HoraryExtraFieldView, 
  HoraryExtraFieldFieldList as HoraryExtraFieldFieldListView,  
  HoraryExtraFieldList as HoraryExtraFieldListView,  
  Scheduling as SchedulingView, 
  SchedulingFieldList as SchedulingFieldListView,  
  SchedulingList as SchedulingListView,     
  Championship as ChampionshipView,   
  ChampionshipList as ChampionshipListView,  
  Subscription as SubscriptionView,   
  SubscriptionList as SubscriptionListView,  
  SubscriptionChampionship as SubscriptionChampionshipView, 
  StandingsList as StandingsListView,  
  StandingsListChampionship as StandingsListChampionshipView, 
  TopScorersList as TopScorersListView,  
  TopScorersListChampionship as TopScorersListChampionshipView,  
  SuspendedPlayersList as SuspendedPlayersListView,  
  SuspendedPlayersChampionship as SuspendedPlayersChampionshipView,   
  PlayerRegistration as PlayerRegistrationView,   
  PlayerRegistrationList as PlayerRegistrationListView,   
  PlayerRegistrationChampionship as PlayerRegistrationChampionshipView,   
  GroupChampionship as GroupChampionshipView,   
  GroupChampionshipList as GroupChampionshipListView,   
  GroupChampionshipChampionship as GroupChampionshipChampionshipView, 
  MatchChampionship as MatchChampionshipView,   
  MatchChampionshipList as MatchChampionshipListView,   
  MatchChampionshipChampionship as MatchChampionshipChampionshipView, 
  MatchSummary as MatchSummaryView,   
  MatchSummaryList as MatchSummaryListView,   
  MatchSummaryChampionship as MatchSummaryChampionshipView, 
  AutomaticGroup as AutomaticGroupView,  
  AutomaticMatch as AutomaticMatchView,    
  Account as AccountView,
  SignUp as SignUpView,
  SignIn as SignInView,
  NotFound as NotFoundView
} from '~/views';

const Routes = () => {
  return (
    <Switch>
      <Redirect
        exact
        from="/"
        to="/dashboard"
      />
      <RouteWithLayout
        component={DashboardView}
        exact
        layout={MainLayout}
        path="/dashboard"   
        isPrivate     
      />
      <RouteWithLayout
        component={PersonListView}
        exact
        layout={MainLayout}
        path="/people"
        isPrivate
      />
      <RouteWithLayout
        component={PersonView}
        exact
        layout={MainLayout}
        path="/person"
        isPrivate
      />
      <RouteWithLayout
        component={TeamListView}
        exact
        layout={MainLayout}
        path="/teams"
        isPrivate
      />
      <RouteWithLayout
        component={TeamView}
        exact
        layout={MainLayout}
        path="/team"
        isPrivate
      />      
      <RouteWithLayout
        component={PlayerListView}
        exact
        layout={MainLayout}
        path="/players"
        isPrivate
      />
      <RouteWithLayout
        component={PlayerView}
        exact
        layout={MainLayout}
        path="/player"
        isPrivate
      />  
      <RouteWithLayout
        component={FieldListView}
        exact
        layout={MainLayout}
        path="/fields"
        isPrivate
      />
      <RouteWithLayout
        component={FieldView}
        exact
        layout={MainLayout}
        path="/field"
        isPrivate
      />  
      <RouteWithLayout
        component={FieldItemFieldListView}
        exact
        layout={MainLayout}
        path="/fieldItensField"
        isPrivate
      />
      <RouteWithLayout
        component={FieldItemListView}
        exact
        layout={MainLayout}
        path="/fieldItens"
        isPrivate
      />
      <RouteWithLayout
        component={FieldItemView}
        exact
        layout={MainLayout}
        path="/fieldItem"
        isPrivate
      /> 
      <RouteWithLayout
        component={HoraryPriceListView}
        exact
        layout={MainLayout}
        path="/horaryPrices"
        isPrivate
      />
      <RouteWithLayout
        component={HoraryPriceFieldListView}
        exact
        layout={MainLayout}
        path="/horaryPricesField"
        isPrivate
      />
      <RouteWithLayout
        component={HoraryPriceView}
        exact
        layout={MainLayout}
        path="/horaryPrice"
        isPrivate
      />  
      <RouteWithLayout
        component={HoraryFieldListView}
        exact
        layout={MainLayout}
        path="/horaryFields"
        isPrivate
      />
      <RouteWithLayout
        component={HoraryFieldFieldListView}
        exact
        layout={MainLayout}
        path="/horaryFieldsField"
        isPrivate
      />      
      <RouteWithLayout
        component={HoraryFieldView}
        exact
        layout={MainLayout}
        path="/horaryField"
        isPrivate
      />  
      <RouteWithLayout
        component={HoraryExtraFieldListView}
        exact
        layout={MainLayout}
        path="/horaryExtraFields"
        isPrivate
      />
      <RouteWithLayout
        component={HoraryExtraFieldFieldListView}
        exact
        layout={MainLayout}
        path="/horaryExtraFieldsField"
        isPrivate
      />      
      <RouteWithLayout
        component={HoraryExtraFieldView}
        exact
        layout={MainLayout}
        path="/horaryExtraField"
        isPrivate
      /> 
      <RouteWithLayout
        component={SchedulingListView}
        exact
        layout={MainLayout}
        path="/schedulings"
        isPrivate
      />
      <RouteWithLayout
        component={SchedulingFieldListView}
        exact
        layout={MainLayout}
        path="/schedulingField"
        isPrivate
      />      
      <RouteWithLayout
        component={SchedulingView}
        exact
        layout={MainLayout}
        path="/scheduling"
        isPrivate
      /> 
      <RouteWithLayout
        component={ChampionshipListView}
        exact
        layout={MainLayout}
        path="/championships"
        isPrivate
      />
      <RouteWithLayout
        component={ChampionshipView}
        exact
        layout={MainLayout}
        path="/championship"
        isPrivate
      />  
      <RouteWithLayout
        component={SubscriptionListView}
        exact
        layout={MainLayout}
        path="/subscriptions"
        isPrivate
      />
      <RouteWithLayout
        component={SubscriptionView}
        exact
        layout={MainLayout}
        path="/subscription"
        isPrivate
      /> 
      <RouteWithLayout
        component={SubscriptionChampionshipView}
        exact
        layout={MainLayout}
        path="/subscriptionChampionship"
        isPrivate
      />
      <RouteWithLayout
        component={StandingsListView}
        exact
        layout={MainLayout}
        path="/standingsList"
        isPrivate
      />
      <RouteWithLayout
        component={StandingsListChampionshipView}
        exact
        layout={MainLayout}
        path="/standingsListChampionship"
        isPrivate
      /> 
      <RouteWithLayout
        component={TopScorersListView}
        exact
        layout={MainLayout}
        path="/topScorersList"
        isPrivate
      />
      <RouteWithLayout
        component={TopScorersListChampionshipView}
        exact
        layout={MainLayout}
        path="/topScorersListChampionship"
        isPrivate
      />       
      <RouteWithLayout
        component={PlayerRegistrationListView}
        exact
        layout={MainLayout}
        path="/playerRegistrations"
        isPrivate
      />
      <RouteWithLayout
        component={PlayerRegistrationView}
        exact
        layout={MainLayout}
        path="/playerRegistration"
        isPrivate
      />  
      <RouteWithLayout
        component={PlayerRegistrationChampionshipView}
        exact
        layout={MainLayout}
        path="/playerRegistrationChampionship"
        isPrivate
      />     
      <RouteWithLayout
        component={GroupChampionshipListView}
        exact
        layout={MainLayout}
        path="/groupChampionships"
        isPrivate
      />
      <RouteWithLayout
        component={GroupChampionshipView}
        exact
        layout={MainLayout}
        path="/groupChampionship"
        isPrivate
      />  
      <RouteWithLayout
        component={GroupChampionshipChampionshipView}
        exact
        layout={MainLayout}
        path="/groupChampionshipChampionship"
        isPrivate
      /> 
      <RouteWithLayout
        component={MatchChampionshipListView}
        exact
        layout={MainLayout}
        path="/matchChampionships"
        isPrivate
      />
      <RouteWithLayout
        component={MatchChampionshipView}
        exact
        layout={MainLayout}
        path="/matchChampionship"
        isPrivate
      />  
      <RouteWithLayout
        component={MatchChampionshipChampionshipView}
        exact
        layout={MainLayout}
        path="/matchChampionshipChampionship"
        isPrivate
      /> 
      <RouteWithLayout
        component={MatchSummaryListView}
        exact
        layout={MainLayout}
        path="/matchSummarys"
        isPrivate
      />
      <RouteWithLayout
        component={MatchSummaryView}
        exact
        layout={MainLayout}
        path="/matchSummary"
        isPrivate
      />  
      <RouteWithLayout
        component={MatchSummaryChampionshipView}
        exact
        layout={MainLayout}
        path="/matchSummaryChampionship"
        isPrivate
      />        
      <RouteWithLayout
        component={AutomaticGroupView}
        exact
        layout={MainLayout}
        path="/automaticGroup"
        isPrivate
      /> 
      <RouteWithLayout
        component={AutomaticMatchView}
        exact
        layout={MainLayout}
        path="/automaticMatch"
        isPrivate
      /> 
      <RouteWithLayout
        component={SuspendedPlayersListView}
        exact
        layout={MainLayout}
        path="/suspendedPlayersList"
        isPrivate
      />
      <RouteWithLayout
        component={SuspendedPlayersChampionshipView}
        exact
        layout={MainLayout}
        path="/suspendedPlayersChampionship"
        isPrivate
      />                                                                  
      <RouteWithLayout
        component={AccountView}
        exact
        layout={MainLayout}
        path="/account"
        isPrivate
      />
      <RouteWithLayout
        component={SignUpView}
        exact
        layout={MinimalLayout}
        path="/sign-up"
      />
      <RouteWithLayout
        component={SignInView}
        exact
        layout={MinimalLayout}
        path="/sign-in"
      />
      <RouteWithLayout
        component={NotFoundView}
        exact
        layout={MinimalLayout}
        path="/not-found"
      />
      <Redirect to="/not-found" />
    </Switch>
  );
};

export default Routes;
