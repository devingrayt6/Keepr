<template>
    <div class="card text-center" style="width: 15rem;">
        <img :src="this.data.img" class="card-img-top" alt="...">
        <div class="card-body">
            <div class="row">
                <div class="col-4"><i class="fab fa-korvue"></i> : {{data.keeps}}</div>
                <div class="col-4"><i class="fas fa-share"></i> : {{data.shares}}</div>
                <div class="col-4"><i class="far fa-eye"></i> : {{data.views}}</div>
            </div>
            <hr>
            <p class="card-title">{{this.data.name}}</p>
            <hr>
            <p class="cursor-pointer close-desc" v-if="showDesc" v-on:click="toggleDescription">x</p>
            <p class="card-text" v-if="showDesc">{{this.data.description}}</p>
            <p class="cursor-pointer" v-on:click="toggleDescription" v-if="!showDesc">...</p>
        </div>
    </div>
</template>

<script>
export default {
    mounted() {},
    props: ['data'],
    methods:{
        toggleDescription(){
            this.showDesc = !this.showDesc;
        }
    },
    computed:{},
    data(){
        return{
            showDesc: false
        }
    },
}
</script>

<style>
.greenCheck{
        color: green;
    }
.cursor-pointer{
    cursor: pointer;
}
.close-desc{
    color: red;
    justify-content: flex-end;
}
hr.style-six {
    border: 0;
    height: 0;
    border-top: 1px solid rgba(0, 0, 0, 0.1);
    border-bottom: 1px solid rgba(255, 255, 255, 0.3);
}
i{
    font-size: 1.25rem;
}
.user-tools{
    display: flex;
    justify-content: space-between;
}
.edit{
    color: turquoise;
}
</style>