<template>
    <div class="card text-center">
        <img :src="this.data.img" class="card-img-top" alt="...">
        <div class="card-body">
            <div class="row">
                <div class="dropdown">
                    <i class="fab fa-korvue ml-3" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"></i> : {{data.keeps}}
                    <div v-if="this.inVault" class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <a class="dropdown-item text-red" href="#" v-on:click="removeFromVault" >Remove from {{this.vaultData.name}}</a>
                    </div>
                    <div v-else class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <strong class="dropdown-item text-primary">Save to a vault:</strong>
                        <a v-for="vault in userVaults" :key="vault.id" class="dropdown-item" href="#" v-on:click="addToVault(vault.id)" >{{vault.name}}</a>
                    </div>
                </div>

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
    mounted() {

    },
    props: ['data','inVault', 'vaultData'],
    methods:{
        toggleDescription(){
            this.showDesc = !this.showDesc;
        },
        addToVault(id){
            let vaultkeep = {
                keepId: this.data.id,
                vaultId: id
            }
            let newKeep = this.data
            newKeep.keeps++;
            this.$store.dispatch("CreateVaultKeep", {vaultKeep:vaultkeep, newKeep:newKeep});
        },
        removeFromVault(){
            let vaultKeep={
                keepId: this.data.id,
                vaultId: this.vaultData.id
            }
            this.$store.dispatch("RemoveFromVault", vaultKeep)
        }
    },
    computed:{
        userVaults(){
            return this.$store.state.vaults;
        }
    },
    data(){
        return{
            showDesc: false,
            vaultId: ''
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
.text-red{
    color: red;
}
</style>