
import Vue from 'vue' //引入Vue包
import VueRouter from 'vue-router' //引入router包


import HomeView from '../components/Che.vue' //引入需要加载的组件模


Vue.use(VueRouter)//进行调用

//创建路由实例
const routes=[
    //绑定一级路由
    {
        path:"/", //地址
        name:'home',//命名
        component: HomeView  //加载的模块
    }
]


// 创建router实例 传routes配置  routes配置为我们定义的路由
const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
  })
//  进行输入
  export default router

