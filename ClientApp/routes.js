import HomePage from 'components/home-page'
import Login from 'components/login-page'
import Projects from 'components/Projects/projects-page'
import ProjectDetails from 'components/Projects/projects-detail-page'
import Forums from 'components/Forums/forums-page'
import ForumReplies from 'components/Forums/ForumDetail/forum-detail-page'
import Polls from 'components/Polls/polls-page'
import PollsNew from 'components/Polls/poll-new'
import Members from 'components/Members/members-page'


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
  { name: 'project_forums', path: '/projects/:project_id/forums', component: Forums },
  { name: 'project_forums_replies', path: '/projects/:project_id/forums/:forum_id', component: ForumReplies },

  { name: 'project_polls', path: '/projects/:project_id/polls', component: Polls },
  { name: 'polls_new', path: '/projects/:project_id/polls/new', component: PollsNew },

  { name: 'project_members', path: '/projects/:project_id/members', component: Members },


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
