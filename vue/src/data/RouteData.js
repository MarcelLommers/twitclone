// Pages
import HelloWorld from "../components/HelloWorld"

import Task1Page from '../pages/Task1Page'
import Task2Page from '../pages/Task2Page'
import Task3Page from '../pages/Task3Page'
import Task4Page from '../pages/Task4Page'

import TwitClonePage from "../pages/TwitClonePage";
import TwitCloneUserListPage from "../pages/TwitCloneUserListPage";
import TwitCloneUserPage from "../pages/TwitCloneUserPage";


export default [
  {
    path: "/home",
    alias: '/',
    name: "Home",
    components: {
      content: HelloWorld
    },
    meta: {
      allowAnonymous: true
    }
  },
  {
    path: "/task1",
    name: "Task1",
    components: {
      content: Task1Page
    },
    meta: {
      allowAnonymous: true
    }
  },
  {
    path: "/task2",
    name: "Task2",
    components: {
      content: Task2Page
    },
    meta: {
      allowAnonymous: true
    }
  },
  {
    path: "/task3",
    name: "Task3",
    components: {
      content: Task3Page
    },
    meta: {
      allowAnonymous: true
    }
  },
  {
    path: "/task4",
    name: "Task4",
    components: {
      content: Task4Page
    },
    meta: {
      allowAnonymous: true
    }
  },
  {
    path: "/twitClone",
    name: "twitClone",
    components: {
      content: TwitClonePage
    },
    meta: {
      allowAnonymous: true
    }
  },
  {
    path: "/twitCloneUserList",
    name: "twitCloneUserList",
    components: {
      content: TwitCloneUserListPage
    },
    meta: {
      allowAnonymous: true
    }
  },
  {
    path: "/twitCloneUser/:userId?",
    name: "twitCloneUser",
    components: {
      content: TwitCloneUserPage
    },
    meta: {
      allowAnonymous: true
    }
  }

]
