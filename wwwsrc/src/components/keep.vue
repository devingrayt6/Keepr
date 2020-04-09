<template>
    <div class="card text-center" style="width: 100%;">
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
            <hr>
            <div class="cursor-pointer user-tools" v-on:click="togglePrivate"><span class="greenCheck" v-if="privateStatus">private <i class="fas fa-lock"></i></span><span class="greycheck" v-else>public <i class="fas fa-lock-open"></i></span></div>
            <!-- <i class="far fa-edit edit"></i> -->
        </div>
    </div>
</template>

<script>
export default {
    mounted() {},
    props: ['data'],
    methods:{
        togglePrivate(){
            let newKeep = this.data;
            newKeep.isPrivate = !this.isPrivate;

            this.$store.dispatch("updateKeepPrivacy", newKeep);
            this.isPrivate = !this.isPrivate;
        },
        toggleDescription(){
            this.showDesc = !this.showDesc;
        }
    },
    computed:{
        privateStatus(){
            return this.isPrivate;
        }
    },
    data(){
        return{
            isPrivate: this.data.isPrivate,
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