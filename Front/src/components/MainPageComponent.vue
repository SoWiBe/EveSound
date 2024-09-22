<template lang="">
    <ul>
        <li v-for="post in posts" ::key="post.id" data-test="post">
            {{ post.data.data.title }}
        </li>
    </ul>
    <div><p>{{ posts }}</p></div>
</template>
<script>
import axios from 'axios'
export default {
    data() {
        return {
            posts: null,
            data: null
        }
    },
    methods: {
        async getPosts() {
            this.posts = await axios.get('http://localhost:8080/api/v1/music', {
                Headers: {

                }
            }).then((result) => {
                console.log(result);
            }).catch((err) => {
                console.log(err.response);
            });
            console.log(this.posts[0]);
        }
       
    },
    mounted() {
        this.getPosts();
    }
}
</script>
<style lang="">
    
</style>