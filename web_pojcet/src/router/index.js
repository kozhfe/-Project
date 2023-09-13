
import Vue from 'vue' //引入Vue包
import Router from 'vue-router' //引入router包


import HomeView from '../components/CheShi.vue' //引入需要加载的组件模


Vue.use(Router)//进行调用


// 创建router实例 传routes配置  routes配置为我们定义的路由
const router = new Router({
    mode: 'history',
    routers:[{
        path:"/", //地址
        //name:'home',//命名
        component: HomeView  //加载的模块
    },{
        path:"/", //地址
        name:'home',//命名
        component: HomeView  //加载的模块
    }]
  })
//  进行输入
  export default router

