import HomePage from 'components/home-page'
import Login from 'components/login-page'
import Projects from 'components/Projects/projects-page'
import ProjectDetails from 'components/Projects/projects-detail-page'
import Forums from 'components/Forums/forums-page'
import Registration from 'components/register-page'
import { requireAuth } from './auth';


export const routes = [
  // Always show link to home page.
  { path: '/', component: HomePage, display: 'Home', style: 'glyphicon glyphicon-home', displayLoggedIn: true, displayLoggedOut: true,  },

  // Only When Logged Out
  { path: '/login', component: Login, display: 'Login', style: 'glyphicon glyphicon-user', displayLoggedIn: false, displayLoggedOut: true, },
  { path: '/register', component: Registration, display: 'Register', style: 'glyphicon glyphicon-asterisk', displayLoggedIn: false, displayLoggedOut: true, },

  { name: 'projects', path: '/projects', component: Projects },
  { name: 'project_details', path: '/projects/:project_id', component: ProjectDetails },
  { name: 'project_forums', path: '/projects/:project_id/forums', component: Forums }


  //// Requires Login
  //{
  //  path: '/counter',
  //  component: CounterExample,
  //  display: 'Counter',
  //  style: 'glyphicon glyphicon-education',
  //  beforeEnter: requireAuth,
  //  displayLoggedIn: true, displayLoggedOut: false, 
  //},
]
