<template>
    <div class="card text-center" style="width: 15rem;">
        <img :src="this.data.img" class="card-img-top" alt="...">
        <div class="card-body">
            <h5 class="card-title">{{this.data.name}}</h5>
            <p class="card-text">{{this.data.description}}</p>
            <span>private</span> <i class="fas fa-check greenCheck" v-if="isPrivate==true"></i><i class="fas fa-check greyCheck" v-else></i>
        </div>
    </div>
</template>

<script>
export default {
    mounted() {},
    props: ['data'],
    data(){
        return{
            isPrivate: this.data.isPrivate
        }
    },
}
</script>

<style>
.greenCheck{
        color: green;
    }
</style>