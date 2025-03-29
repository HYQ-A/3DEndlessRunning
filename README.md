# 3D Endless Runner

一款基于 Unity3D 开发的 3D 无尽跑酷游戏，玩家需操控角色躲避障碍并收集道具，挑战最高分数。项目重点展示游戏核心机制与性能优化实践。

## ✨ 功能亮点

- **角色控制**  
  - 跳跃、碰撞检测系统  
  - 镜头跟随
- **障碍生成**  
  - 使用对象池（Object Pooling）动态管理障碍物，减少实例化开销  
  - 随机生成算法保证关卡多样性
- **UI 与交互**  
  - 自适应分辨率 UI 布局（Canvas + Unity UI）  
  - 实时分数统计与排行榜功能
- **性能优化**  
  - 批处理（Batching）减少 Draw Call  

## 🛠️ 技术栈

- **引擎**: Unity 2022.3  
- **编程语言**: C#  
- **关键插件/工具**:  
  ![Cinemachine](https://img.shields.io/badge/Cinemachine-官方插件-blue)  
  ![Git](https://img.shields.io/badge/Git-版本控制-orange)  
  ![Git LFS](https://img.shields.io/badge/Git%20LFS-大文件管理-red)
- **项目管理**: Markdown 文档化

## 🚀 快速开始

### 环境要求
- Unity Hub + Unity Editor 2022.3
- Git + Git LFS（用于拉取大文件）

### 安装步骤
1. **克隆仓库**（需提前安装 Git LFS）：
   ```bash
   git lfs clone https://github.com/YOUR_USERNAME/3DEndlessRunning.git

##📂 项目结构
3DEndlessRunning/
├── Assets/
│   ├── Scripts/           # 核心逻辑脚本
│   │   ├── Data/          # 数据管理脚本
│   │   ├── GameScene/     # 游戏场景中的脚本
│   │   ├── MainScene/     # 主菜单场景中的脚本
│   │   ├── Object/        # 游戏物品管理脚本
│   │   └── XML/           # 存储管理
│   ├── Scenes/            # 游戏场景
│   ├── Resources/         # 资源
│   │   ├── Prefabs/       # 预制体资源
│   └── Art/               # 美术资源
├── ProjectSettings/       # Unity 项目配置
├── Packages/              # 依赖包清单
└── README.md              # 项目文档
